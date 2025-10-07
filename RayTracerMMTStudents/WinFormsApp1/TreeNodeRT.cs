using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUAS.MMT
{
    class TreeNodeRT:TreeNode
    {
        //public Object Obj { get; set; }

        public RTObject Obj;

        public TreeNodeRT(string name_, RTObject obj_): base(name_)
        {

            Obj = obj_;

        }

    }
}
