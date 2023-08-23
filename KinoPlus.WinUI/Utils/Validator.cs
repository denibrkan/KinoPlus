namespace KinoPlus.WinUI.Utils
{
    public class Validator
    {
        public static bool ValidateControl(Control control, ErrorProvider err, string error)
        {
            var valid = true;

            if (control is TextBox && string.IsNullOrWhiteSpace(control.Text))
                valid = false;
            else if (control is ComboBox && ((ComboBox)control).SelectedIndex < 0)
                valid = false;
            else if (control is PictureBox && ((PictureBox)control).Image == null)
                valid = false;
            else if (control is NumericUpDown && ((NumericUpDown)control).Value == 0)
                valid = false;
            else if (control is RichTextBox && string.IsNullOrWhiteSpace(control.Text))
                valid = false;
            else if (control is ListBox && ((ListBox)control).SelectedValue == null)
                valid = false;

            if (!valid)
                err.SetError(control, error);
            else
                err.Clear();

            return valid;
        }
    }
}