using System.Windows.Forms;

namespace Schoool
{
    public class ChangeDbFormBase<T> : Form
    {
        public delegate void DbChangedHandler(T obj);

        public virtual event DbChangedHandler Inserted;
        public virtual event DbChangedHandler Updated;
        public virtual event DbChangedHandler Deleted;

        protected void OnInserted(T obj)
        {
            Inserted?.Invoke(obj);
        }

        protected void OnUpdated(T obj)
        {
            Updated?.Invoke(obj);
        }

        protected void OnDeleted(T obj)
        {
            Deleted?.Invoke(obj);
        }
    }
}
