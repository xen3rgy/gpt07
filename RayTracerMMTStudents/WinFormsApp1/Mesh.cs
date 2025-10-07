using System;

namespace CUAS.MMT
{
	//base class for a mesh
	public abstract class Mesh:IHittable
    {

        public RTObject? Object;


        public abstract bool Hit(Ray ray_, ref HitRecord record_);


        public abstract void UV(HitRecord hit_, ref double u_, ref double v_); //get uv coordinates


    }
}
