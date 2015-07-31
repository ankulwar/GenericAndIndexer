class Program
    {
        static void Main(string[] args)
        {
            //You want to create logic which is of very general data type
            Console.WriteLine(Compare<int>.Check(1,2));
            Console.WriteLine(Compare<string>.Check("BA", "BA"));
            Console.ReadLine();

            var number = new GenericList<int>();
            number.Add(10);

            var book = new GenericList<Book>();
            book.Add(new Book());            

            var obj= new IndexerExample();
            Book byid = obj[1]; //Indexer
            Book byname = obj["Balaji2"]; //Indexer
        }

        public static class Compare<T>
        {
            public static bool Check(T data1, T data2)
            {
                return data1.Equals(data2);
            }
        }


        public class Book
        {
            public int Id { get; set; }
            public string Name { get; set; }

        }
        
        public class GenericList<T>
        {
            public void Add(T value) { }
        }

        //Constraint on generics
        //Where T : Class
        //T: IComparable
        //T:Struct
        //T:new()
        public class Utilies<T> where T : IComparable, new()   
        {
            public int Max(int a, int b) { return a > b ? a : b; }
            public T Max(T a, T b) { return a.CompareTo(b) > 0 ? a : b; }

            public void DoSomthing(T value) {
                var obj = new T(); /*to remove error add inherit new() classs*/ 
            }

            //public T Max<T>(T a, T b) where T : IComparable { return a.CompareTo(b) > 0 ? a : b; }
        }

        public class IndexerExample
        {
            List<Book> books = new List<Book>();

            public IndexerExample()
            {
                books.Add(new Book {Id=1, Name="Balaji 1"});
                books.Add(new Book { Id = 2, Name = "Balaji 2" });
                books.Add(new Book { Id = 3, Name = "Balaji 3" });
                books.Add(new Book { Id = 4, Name = "Balaji 4" });
            }

            /*Indexer are used when we want to access value from collection which has good performace*/
            public Book this[int id]
            {
                get { return books.FirstOrDefault(b => b.Id == id); }
            }

            public Book this[string name]
            {
                get { return books.FirstOrDefault(b => b.Name == name); }
            }
        }
    }
