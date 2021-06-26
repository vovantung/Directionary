namespace Directionary.Web.Models
{
    public class PostTagViewModel
    {
        public int PostID { set; get; }

        public string TagID { set; get; }

        public virtual PostViewModel PostViewModel { set; get; }

        public virtual TagViewModel TagViewModel { set; get; }
    }
}