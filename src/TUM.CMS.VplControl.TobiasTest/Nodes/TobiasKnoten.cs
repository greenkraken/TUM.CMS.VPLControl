using System.Windows;
using System.Windows.Controls;
using TUM.CMS.VplControl.Core;

namespace TUM.CMS.VplControl.TobiasTest.Nodes
{
    public class TobiasKnoten : Node
    {
        public TobiasKnoten(Core.VplControl hostCanvas) : base(hostCanvas)
        {

            AddInputPortToNode("function", typeof(string));

            IsResizeable = true;
            var KoordSys = new DataGrid() ;


            AddControlToNode(KoordSys);



        }

        public override void Calculate()
        {
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
