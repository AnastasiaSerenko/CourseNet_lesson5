using System;

namespace ConsoleApp1
{
    class Vector
    {    
        private int _x, _y, _z;     
        
        #region Constructors    
        public Vector(int x, int y, int z) {
            _x = x;
            _y = y;
            _z = z;
        }
        
        public Vector(int[] coordinates) {
            if (coordinates.Length == 3) {             
                _x = coordinates[0];
                _y = coordinates[1];
                _z = coordinates[2];
            }
            else{             
                _x = 0;
                _y = 0;
                _z = 0;
            }
        }       
        #endregion

        #region SetGetMethods   
        public int X
        {
            get { return _x; }
            set { _x = value; }
        }

        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public int Z
        {
            get { return _z; }
            set { _z = value; }
        }
        #endregion

        #region UnstaticMethods   
        public double GetLength() {
            return Math.Sqrt(Math.Pow(_x, 2) +
                Math.Pow(_y, 2) +
                Math.Pow(_z, 2));
        }

        public override string ToString() {
            return $"{{{_x}; {_y}; {_z}}}";
        }
        #endregion

        #region StaticMethods 

        public static int ScalarMultiplier(Vector vector1, Vector vector2)
        {
            return (vector1._x * vector2._x +
                vector1._y * vector2._y +
                vector1._z * vector2._z);
        }

        public static double GetAngle(Vector vector1, Vector vector2)
        {
            return (ScalarMultiplier(vector1, vector2) /
                (vector1.GetLength() * vector2.GetLength()));
        }

        public static Vector VectorMultiplier(Vector vector1, Vector vector2) {
            int x, y, z;
            x = vector1._y * vector2._z - vector1._z * vector2._y;
            y = vector1._z * vector2._x - vector1._x * vector2._z;
            z = vector1._x * vector2._y - vector1._y * vector2._x;
            Vector rez = new Vector(x, y, z);
            return rez;
        }

        public static Vector Summation(Vector vector1, Vector vector2)
        {
            Vector rez = new Vector((vector1._x + vector2._x),
                (vector1._y + vector2._y),
                (vector1._z + vector2._z));
            return rez;
        }

        public static Vector Subtraction(Vector vector1, Vector vector2)
        {
            Vector rez = new Vector((vector1._x - vector2._x),
                (vector1._y - vector2._y),
                (vector1._z - vector2._z));
            return rez;
        }
        #endregion

        #region OverloadOperators    

        public static Vector operator *(Vector vector1, Vector vector2)
        {
            return VectorMultiplier(vector1, vector2);
        }
        public static Vector operator +(Vector vector1, Vector vector2) {
            return Summation(vector1, vector2);
        }       
        
        public static Vector operator -(Vector vector1, Vector vector2) {
            return Subtraction(vector1, vector2);
        }            
        #endregion
    }
}
