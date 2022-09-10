using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace PrototypePattern
{
    [Serializable]
    class Circle : IFigure
    {
        int radius;
        public Point Point { get; set; }
        public Circle(int r, int x, int y)
        {
            radius = r;
            Point = new Point { X = x, Y = y };
        }

        public IFigure Clone()
        {
            return (IFigure)MemberwiseClone();
        }

        public object DeepCopy()
        {
            object figure;
            using (MemoryStream tempStream = new MemoryStream())
            {
                BinaryFormatter binFormatter = new BinaryFormatter(null,
                    new StreamingContext(StreamingContextStates.Clone));

                binFormatter.Serialize(tempStream, this);
                tempStream.Seek(0, SeekOrigin.Begin);

                figure = binFormatter.Deserialize(tempStream);
            }
            return figure;
        }
        public void GetInfo()
        {
            Console.WriteLine("Круг радиусом {0} и центром в точке ({1}, {2})", radius, Point.X, Point.Y);
        }
    }
}
