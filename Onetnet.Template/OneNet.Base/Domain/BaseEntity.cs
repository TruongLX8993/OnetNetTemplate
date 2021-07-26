using System.Collections.Generic;

namespace OneNet.Base.Domain
{
    public class BaseEntity<TKey>
    {
        private IList<BaseEvent> _events = new List<BaseEvent>();
        public virtual TKey Id { get; set; }

        public virtual void CleanEvent()
        {
            _events.Clear();
        }

        public virtual void Raise()
        {
        }
    }
}