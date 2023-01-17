using System.Windows.Forms;

namespace Liberty_Travel_And_Tours
{
    internal class userInfo
    {
        
        public string email { get; set; }
        public string username { get; set; }
        public string pass { get; set; }

        private static string error= "username doesnot exits!";
        public static void geterror()
        {
            MessageBox.Show(error);
        }
        public static bool isequal(userInfo u1, userInfo u2)
        {
               if(u1 == null || u2 == null) { return false; }
               if(u1.username != u2.username) {
                error = "username doesnot exits!";
                return false;
            }
               else if(u1.pass != u2.pass)
            {
                error = "username and password doesnot match!";
                return false;

            }
            return true;

        }
    }
}