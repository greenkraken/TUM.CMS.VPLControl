using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml;
using TUM.CMS.VplControl.Core;

// Shows a String Window to write down your mathematical Function.
namespace TUM.CMS.VplControl.TobiasTest.Nodes
{
    public class InsertFunction : Node
    {
        public InsertFunction(Core.VplControl hostCanvas) : base(hostCanvas)
        {

            AddOutputPortToNode("function", typeof(string));

            var label = new Label
            {
                Content = "f(x)=",
                FontSize = 14,
                HorizontalContentAlignment = HorizontalAlignment.Left,
            };

            var function = new TextBox
            {
                MinWidth = 200,
                FontSize = 14,
                HorizontalAlignment = HorizontalAlignment.Stretch
            };

            function.TextChanged += function_TextChanged;
            function.KeyUp += function_KeyUp;

            MouseEnter += InsertFunction_MouseEnter;
            MouseLeave += InsertFunction_MouseLeave;

            AddControlToNode(label);
            AddControlToNode(function);
            
        }

        private void InsertFunction_MouseEnter(object sender, MouseEventArgs e)
        {
            ControlElements[1].Focus();
        }
        private void InsertFunction_MouseLeave(object sender, MouseEventArgs e)
        {
            Border.Focusable = true;
            Border.Focus();
            Border.Focusable = false;
        }

        private void function_KeyUp(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void function_TextChanged(object sender, TextChangedEventArgs e)
        {
            Calculate();
        }

        public override void Calculate()
        {
            var function = ControlElements[1] as TextBox;
            if (function == null) return;

            OutputPorts[0].Data = function.Text;

        }

        public override void SerializeNetwork(XmlWriter xmlWriter)
        {
            base.SerializeNetwork(xmlWriter);

            var function = ControlElements[1] as TextBox;
            if (function == null) return;

            xmlWriter.WriteStartAttribute("Text");
            xmlWriter.WriteValue(function.Text);
            xmlWriter.WriteEndAttribute();
        }

        public override void DeserializeNetwork(XmlReader xmlReader)
        {
            base.DeserializeNetwork(xmlReader);

            var function = ControlElements[1] as TextBox;
            if (function == null) return;

            function.Text = xmlReader.GetAttribute("Text");
        }

        public override Node Clone()
        {
            return new InsertFunction(HostCanvas);
            
        }
    }
}
