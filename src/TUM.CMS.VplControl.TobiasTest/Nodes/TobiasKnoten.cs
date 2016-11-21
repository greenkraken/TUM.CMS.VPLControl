using System.Windows.Controls;
using TUM.CMS.VplControl.Core;

namespace TUM.CMS.VplControl.TobiasTest.Nodes
{
    public class TobiasKnoten : Node
    {
        public TobiasKnoten(Core.VplControl hostCanvas) : base(hostCanvas)
        {

            AddInputPortToNode("Eingangswert1", typeof(double));
            AddOutputPortToNode("Ausgangswert 1", typeof(double));

            var textbox = new TextBox();

            AddControlToNode(textbox);


        }

        public override void Calculate()
        {

            var inputvalue = (double)InputPorts[0].Data;

            OutputPorts[0].Data = inputvalue * 2;

            // var test = true; 
            // throw new NotImplementedException();
        }

        public override Node Clone()
        {
            // throw new NotImplementedException();
            return null;
        }
    }
}
