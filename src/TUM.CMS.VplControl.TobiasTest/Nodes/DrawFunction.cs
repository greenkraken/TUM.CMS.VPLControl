using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUM.CMS.VplControl.Core;

namespace TUM.CMS.VplControl.TobiasTest.Nodes
{
    public class DrawFunction : Node
    {
        public DrawFunction(Core.VplControl hostCanvas) : base(hostCanvas)
        {

            AddInputPortToNode("function", typeof(string));

            AddOutputPortToNode("table", typeof(double));



        }

        public override void Calculate()
        {
            var function = InputPorts[0];

            double y;
            double x;
            double a;
            a = 0.1;
            double z;
            z = 10;

            for (double i = 0; i < z; i += a)
            {

                x = i;
                //get string from input (how to convert?)
                y = x+2;
                //plot x,y ?

            }



            OutputPorts[0] = y;

        }

        public override Node Clone()
        {
            return new InsertFunction(HostCanvas)
            {
                Top = Top,
                Left = Left
            };
        }
    }
}
