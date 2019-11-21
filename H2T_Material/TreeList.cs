using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Handler;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.ViewInfo;
using System.Reflection;
using DevExpress.XtraTreeList.Painter;

namespace H2T_Material {
    public class TreeList : DevExpress.XtraTreeList.TreeList {
        private bool isMultiColumnSelectionEnabled;

        /// <summary>
        /// When multi column selection is enabled NodeCellStyle event should be disabled.
        /// </summary>        
        public bool IsMultiColumnSelectionEnabled {
            get { return isMultiColumnSelectionEnabled; }
            set { isMultiColumnSelectionEnabled = value; }
        }

        protected override TreeListHandler CreateHandler() { return new MyTreeListHandler(this); }

        protected override TreeListViewInfo CreateViewInfo() { return new MyTreeListViewInfo(this); }

        protected override TreeListPainter CreatePainter() { return new CustomTreeListPainter(); }

        internal void RaiseGetStateImageInternal(TreeListNode node, ref int stateImageIndex) {
            this.RaiseGetStateImage(node, ref stateImageIndex);
        }

        public int GetInternalImageIndexFromDatasource(TreeListNode node) {
            return base.GetImageIndexFromDataSource(node);
        }

        /// <summary>
        /// Treelist control override on loaded event. 
        /// </summary>
        protected override void OnLoaded() {
            base.OnLoaded();

            //sets the focused row back color
            Appearance.FocusedRow.BackColor = Color.FromArgb(100, SystemColors.Highlight);
            Appearance.FocusedRow.BackColor2 = Color.FromArgb(100, SystemColors.Highlight);

            Appearance.SelectedRow.BackColor = Color.FromArgb(100, SystemColors.Highlight);
            Appearance.SelectedRow.BackColor2 = Color.FromArgb(100, SystemColors.Highlight);

            Appearance.FocusedRow.Options.UseBackColor = true;
            Appearance.SelectedRow.Options.UseBackColor = true;

            ShowButtonMode = ShowButtonModeEnum.ShowForFocusedRow;
        }

        void TreeList_NodeCellStyle(object sender, GetCustomNodeCellStyleEventArgs e) {
            if (e.Node.Selected && !isMultiColumnSelectionEnabled) {
                e.Appearance.BackColor = Color.FromArgb(100, SystemColors.Highlight);
                e.Appearance.BackColor2 = Color.FromArgb(100, SystemColors.Highlight);
            }
        }

        private void InitializeComponent() {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // TreeList
            // 
            this.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.OptionsBehavior.AutoChangeParent = false;
            this.OptionsBehavior.CloseEditorOnLostFocus = false;
            this.OptionsBehavior.KeepSelectedOnClick = false;
            this.OptionsBehavior.SmartMouseHover = false;
            this.OptionsBehavior.AllowIncrementalSearch = true;
            this.OptionsView.AutoWidth = false;
            this.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.Appearance.HeaderPanel.TextOptions.HAlignment = HorzAlignment.Center;

            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        public bool AllowMultiCellEdit { get; set; }

        public bool IsNodeCellRightClickEnabled { get; set; }

        public TreeList() : this(null) { }

        public TreeList(DevExpress.XtraTreeList.TreeList treelist)
            : base(treelist) {
            //MouseDown += TreeList_MouseDown;
            //NodeCellStyle += TreeList_NodeCellStyle;
        }


        /// <summary>
        /// Handles the MouseDown event of the TreeList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
        void TreeList_MouseDown(object sender, MouseEventArgs e) {
            Point pt = new Point(e.X, e.Y);
            TreeListHitInfo hit = CalcHitInfo(pt);

            if (this.FocusedNode != null) {
                if (hit != null && hit.Node != null) {
                    if (e.Button == MouseButtons.Left && !(this.OptionsSelection.MultiSelect)) {
                        FocusedNode.Selected = true;
                    }

                    //Prevents row selection on mouse right-click.
                    if (!IsNodeCellRightClickEnabled && e.Button == MouseButtons.Right) {
                        DevExpress.Utils.DXMouseEventArgs args = DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e);
                        if (args != null) { args.Handled = true; }
                    }

                    if (this.AllowMultiCellEdit && !(this.OptionsSelection.MultiSelect)) {
                        if (this.FocusedNode.Selected) {
                            if ((Control.ModifierKeys & (Keys.Shift | Keys.Control)) == 0) {
                                if (this.Selection.Contains(hit.Node)) {
                                    this.FocusedNode = hit.Node;
                                    this.FocusedColumn = hit.Column;
                                    this.ShowEditor();

                                    if (this.ActiveEditor != null) {
                                        BaseEdit ed = this.ActiveEditor;
                                        ed.SendMouse(ed.PointToClient(this.PointToScreen(e.Location)), e.Button);
                                        DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    /// <summary>
    /// This class inherits TreeListHandler to override the CreateState method to handle outer dragging
    /// </summary>
    public class MyTreeListHandler : TreeListHandler {
        /// <summary>
        /// constructor inherits base
        /// </summary>
        public MyTreeListHandler(TreeList treeList) : base(treeList) { }

        /// <summary>
        /// Overrides CreateState method
        /// Returns MyOuterDraggingState class if it is OuterDragging, else base state
        /// </summary>
        protected override TreeListControlState CreateState(TreeListState state) {
            if (state == TreeListState.OuterDragging) {
                return new MyOuterDraggingState(this);
            }
            return base.CreateState(state);
        }
    }

    /// <summary>
    /// This class inherits OLEDraggingState to handle the blue arrow icon when it is outer dragging
    /// </summary>
    public class MyOuterDraggingState : TreeListHandler.OLEDraggingState {
        /// <summary>
        /// constructor inherits base
        /// </summary>
        public MyOuterDraggingState(TreeListHandler handler) : base(handler) { }

        /// <summary>
        /// Overrides DragLeave to set the state to regular
        /// </summary>
        public override void DragLeave() {
            base.DragLeave();
            base.SetState(base.Regular);
        }

        /// <summary>
        /// Overrides DragOver for the down blue arrow icon
        /// </summary>
        public override void DragOver(DragEventArgs e) {
            RowInfo rowInfo = base.Data.DragInfo.RowInfo;
            bool flag = (e.KeyState & 4) != 0;
            Point point = base.TreeList.PointToClient(new Point(e.X, e.Y));
            DXDragEventArgs args = base.TreeList.GetDXDragEventArgs(e);
            DragInsertPosition position = args.DragInsertPosition;
            position = DragInsertPosition.AsChild;
            if (base.TreeList.DragNodesMode != TreeListDragNodesMode.Standard) {
                if ((rowInfo != null) && !flag) {
                    int num = rowInfo.Bounds.Height / 3;
                    if ((point.Y <= rowInfo.Bounds.Bottom) && (point.Y >= (rowInfo.Bounds.Bottom - num))) {
                        position = DragInsertPosition.After;
                    }
                    if ((point.Y >= rowInfo.Bounds.Top) && (point.Y <= (rowInfo.Bounds.Top + num))) {
                        position = DragInsertPosition.Before;
                    }
                }
            }
            base.Data.RefreshDragArrow(position, (e.KeyState & 8) != 0, e);
            DoDragging(e);
        }
        /// <summary>
        /// Overrides to get the treelist state as OuterDragging
        /// </summary>
        public sealed override TreeListState State {
            get { return TreeListState.OuterDragging; }
        }
    }

    /// <summary>
    /// This class inherits TreeListViewInfo to hide the empty space if state image is not assigned.
    /// </summary>
    public class MyTreeListViewInfo : TreeListViewInfo {
        public MyTreeListViewInfo(TreeList treeList) : base(treeList) { }

        
        protected override Point GetDataBoundsLocation(TreeListNode node, int top) {
            Point result = base.GetDataBoundsLocation(node, top);

            if ((TreeList as TreeList).SelectImageList != null) {
                int imageIndexFromDataSource = (TreeList as TreeList).GetInternalImageIndexFromDatasource(node);

                if (Size.Empty != RC.SelectImageSize && -2 == imageIndexFromDataSource) {
                    result.X -= RC.SelectImageSize.Width + 1;
                }

                if (Size.Empty != RC.StateImageSize && -2 == imageIndexFromDataSource) {
                    result.X -= RC.StateImageSize.Width + 1;
                }
            }
            else {
                int stateImageIndex = node.StateImageIndex;
                TreeList.RaiseGetStateImageInternal(node, ref stateImageIndex);

                if (Size.Empty != RC.SelectImageSize && -1 == stateImageIndex) {
                    result.X -= RC.SelectImageSize.Width + 1;
                }

                if (Size.Empty != RC.StateImageSize && -1 == stateImageIndex) {
                    result.X -= RC.StateImageSize.Width + 1;
                }
            }

            return result;
        }

        protected override void CalcStateImage(RowInfo ri) {
            base.CalcStateImage(ri);

            if (Size.Empty != RC.SelectImageSize && -1 == ri.Node.SelectImageIndex) {
                ri.StateImageLocation.X -= RC.SelectImageSize.Width + 1;
            }
        }

        protected override void CalcSelectImage(RowInfo ri) {
            base.CalcSelectImage(ri);

            if (-1 == ri.Node.SelectImageIndex) {
                ri.SelectImageLocation = Point.Empty;
            }
        }

        public new TreeList TreeList {
            get { return base.TreeList as TreeList; }
        }
    }

    public class CustomTreeListPainter : TreeListPainter
    {
        internal enum RowIndentItem { None, Root, FirstRoot, LastRoot, Parent, Single, NextChild, LastChild }

        protected override void DrawIndents(DevExpress.XtraTreeList.ViewInfo.IndentInfo indentInfo, int hlw)
        {
            if (NeedsRedraw(indentInfo.Bounds) && indentInfo.TreeLineBrush != null)
            {
                try
                {
                    Rectangle indentItem = new Rectangle(indentInfo.Bounds.Location,
                        new Size(indentInfo.LevelWidth, indentInfo.Bounds.Height + hlw));
                    int actualRowHeight = DrawInfo.ViewInfo.TreeList.OptionsView.ExpandButtonCentered ? indentItem.Height : indentInfo.Bounds.Height;
                    Brush defaultBrush = indentInfo.TreeLineBrush;
                    for (int i = 0; i < indentInfo.IndentItems.Count; i++)
                    {
                        RowIndentItem rii = (RowIndentItem)indentInfo.IndentItems[i];
                        if (i > 0)
                            indentInfo.TreeLineBrush = Brushes.Red;
                        switch (rii)
                        {
                            case RowIndentItem.FirstRoot:
                                DrawFirstRootIndentItem(indentItem, indentInfo.TreeLineBrush, actualRowHeight);
                                break;
                            case RowIndentItem.Root:
                                DrawRootIndentItem(indentItem, indentInfo.TreeLineBrush);
                                break;
                            case RowIndentItem.LastRoot:
                                DrawLastRootIndentItem(indentItem, indentInfo.TreeLineBrush, actualRowHeight);
                                break;
                            case RowIndentItem.Parent:
                                DrawParentIndentItem(indentItem, indentInfo.TreeLineBrush, actualRowHeight);
                                break;
                            case RowIndentItem.Single:
                                DrawSingleIndentItem(indentItem, indentInfo.TreeLineBrush, actualRowHeight);
                                break;
                            case RowIndentItem.NextChild:
                                DrawNextChildIndentItem(indentItem, indentInfo.TreeLineBrush, actualRowHeight);
                                break;
                            case RowIndentItem.LastChild:
                                DrawLastChildIndentItem(indentItem, indentInfo.TreeLineBrush, actualRowHeight);
                                break;
                            case RowIndentItem.None:
                                break;
                        }
                        indentItem.X += indentInfo.LevelWidth;
                        indentInfo.TreeLineBrush = defaultBrush;
                    }
                }
                catch { }
            }
        }
    }
}