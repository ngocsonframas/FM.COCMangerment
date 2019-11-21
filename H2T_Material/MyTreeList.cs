using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using H2T_BaseSys.Common;

namespace H2T_Material
{
    class MyTreeList : DevExpress.XtraTreeList.TreeList
    {
        public MyTreeList() {
            state = new TreeListViewState(this);
        }
        TreeListViewState state;
        protected MyTreeList(object ignore)
            : base(ignore)
        { }
        bool searchStart = false;
        public override void FilterNodes() {
            base.FilterNodes();
            if (IsFindFilterActive || ActiveFilterString != string.Empty) {
                if (!searchStart) {
                    searchStart = true;
                    state.SaveState();
                }
                foreach (TreeListNode node in Nodes.Where(n=>n.Visible).ToList()) {
                    node.Expanded = true;
                }
            }
            else {
                searchStart = false;
                state.LoadState();
            }
        }
    }
}
