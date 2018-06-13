using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_работа_14
{
    class JournalEntry
    {
        public string CollectionName { get; set; }
        public string Change { get; set; }
        public string ObjectStr { get; set; }

        public JournalEntry(string collectionName, string change, string objectStr)
        {
            CollectionName = collectionName;
            Change = change;
            ObjectStr = objectStr;
        }

        public override string ToString()
        {
            return $"Имя коллекции: {CollectionName}\n Изменение: {Change}\n Объект: ({ObjectStr})\n";
        }
    }
    class Journal : IEnumerable
    {
        public List<JournalEntry> journal;

        public Journal()
        {
            journal = new List<JournalEntry>();
        }

        public JournalEntry this[int index]
        {
            get => journal[index];
            set => journal[index] = value;
        }
        public void CollectionCountChanged(object source, CollectionHandlerEventArgs args)
        {
            JournalEntry newEntry = new JournalEntry(args.Name, args.Change, args.Obj.ToString());
            journal.Add(newEntry);
        }

        public void CollectionReferenceChanged(object source, CollectionHandlerEventArgs args)
        {
            JournalEntry newEntry = new JournalEntry(args.Name, args.Change, args.Obj.ToString());
            journal.Add(newEntry);
        }

        public IEnumerator GetEnumerator()
        {
            foreach (JournalEntry journalEntry in journal)
                yield return journalEntry;
        }
    }
}
