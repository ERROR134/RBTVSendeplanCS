using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBTVSendeplanCS 
{
    
    public class MyList<T> : List<T>
    {
        //Custom list with an itemcountchange event
        public event ItemCountChangedHandler ItemCountChanged;
        public delegate void ItemCountChangedHandler(int oldCount, int newCount, MyList<T> sender);

        public MyList() : base()
        {
          
        }

         
          public void Add(T item)
         {
             int old = base.Count;
             base.Add(item);
             if (old != base.Count && ItemCountChanged != null) ItemCountChanged(old, base.Count, this);
         }

          public void AddRange(IEnumerable<T> collection)
          {
              int old = base.Count;
              base.AddRange(collection);
              if (old != base.Count && ItemCountChanged != null) ItemCountChanged(old, base.Count, this);
          }

          public void Remove(T item)
        {
            int old = base.Count;
            base.Remove(item);
            if (old != base.Count && ItemCountChanged != null) ItemCountChanged(old, base.Count, this);
        }

          public void RemoveAt(int index)
        {
            int old = base.Count;
            base.RemoveAt(index);
            if (old != base.Count && ItemCountChanged != null) ItemCountChanged(old, base.Count, this);
        }

          public void RemoveAll(Predicate<T> match)
        {
            int old = base.Count;
            base.RemoveAll(match);
            if (old != base.Count && ItemCountChanged != null) ItemCountChanged(old, base.Count, this);
        }

          public void RemoveRange(int index, int count)
        {
            int old = base.Count;
            base.RemoveRange(index, count);
            if (old != base.Count && ItemCountChanged != null) ItemCountChanged(old, base.Count, this);
        }

          public void Clear()
        {
            int old = base.Count;
            base.Clear();
            if (old != base.Count && ItemCountChanged != null) ItemCountChanged(old, base.Count, this);
        }

          public void Insert(int index, T item)
        {
            int old = base.Count;
            base.Insert(index, item);
            if (old != base.Count && ItemCountChanged != null) ItemCountChanged(old, base.Count, this);
        }

          public void InsertRange(int index, IEnumerable<T> collection)
        {
            int old = base.Count;
            base.InsertRange(index, collection);
            if (old != base.Count && ItemCountChanged != null) ItemCountChanged(old, base.Count, this);
        }


    }
}
