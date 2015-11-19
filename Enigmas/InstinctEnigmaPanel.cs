using System.Drawing;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    public class InstinctEnigmaPanel : EnigmaPanel
    {
        public InstinctEnigmaPanel()
        {
           Label lblReponse = new Label();
            Label lblTexte = new Label();

            Panel pnlImage = new Panel();



            lblReponse.Text = "Réponse A : \n" + "Réponse B : \n" + "Réponse C : \n";
            lblReponse.Font = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold);
            lblReponse.Size = new Size(150, 70);
            lblReponse.Location = new Point(0, 0);
           
           
            


            lblTexte.Text = "Vous vous réveillez dans une baignoire.";
            lblTexte.Font = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold);
            lblTexte.Size = new Size(400, 30);
            lblTexte.Location = new Point(470, 0);
         
            
            
           
      
           Controls.Add(lblReponse);
            Controls.Add(lblTexte);

            pnlImage.Width = 800;
            pnlImage.Height = 600;
           //pnlImage.BackColor = Color.BlueViolet;

            pnlImage.BackgroundImage = Properties.Resources.depart;
            Controls.Add(pnlImage);
            



            
        }
     
    }
}
