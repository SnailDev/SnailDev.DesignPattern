using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Visitor
{
    /// <summary>
    /// 对象结构
    /// </summary>
    public class ObjectStructure
    {
        private List<Element> elements = new List<Element>();

        public List<Element> Elements
        {
            get
            {
                return elements;
            }
        }

        public ObjectStructure()
        {
            Random ran = new Random();
            for (int i = 0; i < 6; i++)
            {
                int ranNum = ran.Next(10);
                if (ranNum>5)
                {
                    elements.Add(new ElementA());
                }
                else
                {
                    elements.Add(new ElementB());
                }
            }
        }
    }
}
