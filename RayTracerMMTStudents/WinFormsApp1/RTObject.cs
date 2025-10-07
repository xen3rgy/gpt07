using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUAS.MMT
{
   public class RTObject
    {

        public string Name { get; set; }

        public Vector Position { get; set; } //transform part

        public Vector Rotation { get; set; }

        public Vector Scale { get; set; }


        RTObject? Parent = null;

        List<RTObject>? Children = null;


        public Material? AMaterial = null; //todo: use list of components

        public Mesh? AMesh = null;

        public Light? ALight = null;

        public bool Active { get; set; } = true;

        public RTObject()
        {
            Position = new Vector(0,0,0);

            Rotation = new Vector(0, 0, 0);

            Scale = new Vector(1, 1, 1);;

            Name = "RTObject";

        }

        public RTObject(Vector position, string name_ = "RTObject")
        {
            Position = position;

            Scale = new Vector(1, 1, 1);

            Rotation = new Vector(0, 0, 0);

            Name = name_;

        }
    }
}
