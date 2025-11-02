using Client.UserControls;
using Common.Communication;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.GuiController
{
    public class DutyTermGuiController
    {
        private UCAddDutyTerm addDutyTerm;
        TerminDezurstva td;
        public Control CreateAddDutyTerm()
        {
            addDutyTerm = new UCAddDutyTerm();

            addDutyTerm.BtnUbaci.Click += UbaciTermin;

            return addDutyTerm;
        }

        private void UbaciTermin(object? sender, EventArgs e)
        {
            try
            {
                td = new TerminDezurstva();

                td.Smena = int.Parse(addDutyTerm.TxtSmena.Text);

                Response response = Communication.Instance.AddTerminDezurstva(td);
                if (response.ExceptionMessage == null)
                {
                    MessageBox.Show("Систем је запамтио термин дежурства.");
                }
                else
                {
                    MessageBox.Show("Систем не може да запамти термин дежурства.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Систем не може да запамти термин дежурства.");
            }
        }
    }
}
