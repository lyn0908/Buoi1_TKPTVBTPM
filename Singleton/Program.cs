namespace Singleton
{
    public class Singleton
    {
        private static Singleton _instance;
        private static readonly object _lock = new object();

        // Constructor private để ngăn không cho tạo đối tượng từ bên ngoài
        private Singleton()
        {
        }

        // Phương thức để lấy thể hiện duy nhất
        public static Singleton Instance
        {
            get
            {
                // Kiểm tra xem đã có thể hiện chưa
                if (_instance == null)
                {
                    // Đảm bảo thread-safe
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new Singleton();
                        }
                    }
                }
                return _instance;
            }
        }

        public void SomeBusinessLogic()
        {
            Console.WriteLine("Executing some business logic.");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Lấy thể hiện duy nhất của Singleton
            Singleton singleton = Singleton.Instance;

            // Gọi phương thức của singleton
            singleton.SomeBusinessLogic();

            // Kiểm tra xem cả hai biến tham chiếu có phải là cùng một đối tượng không
            Singleton anotherSingleton = Singleton.Instance;
            Console.WriteLine(ReferenceEquals(singleton, anotherSingleton) ? "Both are the same instance." : "Different instances.");
        }
    }
}