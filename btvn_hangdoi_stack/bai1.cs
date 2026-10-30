using System.Diagnostics;

public class bai1
{
    public static void Main1(string[] args)
    {
        static int checkbalance(string s)
        {
            var st = new Stack<(char ch, int a)>();
            //duyệt qua từng kí tự
            for (int i = 0; i<s.Length; i++)
            {
                char c = s[i];
                //gặp ngoặc mở thì push vô stack
                if (c == '{' || c == '[' || c == '(')
                {
                    st.Push((c, i));
                }
                //gặp ngoặc đóng mà trong stack không có ngoặc mở 
                else if (c == '}' || c == ']' || c == ')')
                {
                    if (st.Count == 0)
                    {
                        return i;
                    }
                    //ngoặc mở và ngoạc đóng khác nhau
                    var d = st.Pop();
                    if ((d.ch == '(' && c != ')') || (d.ch == '[' && c != ']') || (d.ch == '{' && c != '}'))
                    {
                        return i;
                    }
                }
                //chạy xong vòng lặp mà còn dư ngoặc mở
            }
            if (st.Count > 0)
            {
                return st.ToArray()[st.Count - 1].a;
            }

            return -1;
        }
        //string s = Console.ReadLine();
        //int check = checkbalance(s);
        //if (check == -1) Console.WriteLine("HOP LE");
        //else Console.WriteLine($"SAI tai vi tri {check}");
        //Console.WriteLine("--- CHẠY CA KIỂM THỬ 9 ---");

        //// Sinh chuỗi 1.000.000 ký tự (nửa đóng nửa mở)
        //string str9 = new string('(', 500000) + new string(')', 500000);

        //// Bắt đầu bấm giờ
        Stopwatch sw = Stopwatch.StartNew();
        //int result9 = checkbalance(str9);
        sw.Stop(); // Dừng bấm giờ

        //// In kết quả
        //if (result9 == -1) Console.WriteLine("Kết quả: HOP LE");
        //else Console.WriteLine($"Kết quả: SAI tai vi tri {result9}");
        //Console.WriteLine($"Thời gian chạy: {sw.ElapsedMilliseconds} ms (Yêu cầu < 1000 ms)\n");

        Console.WriteLine("--- CHẠY CA KIỂM THỬ 10 ---");

        // Sinh chuỗi 1.000.000 ký tự toàn dấu ngoặc mở
        string str10 = new string('(', 1000000);

        // Bắt đầu bấm giờ lại từ đầu
        sw.Restart();
        int result10 = checkbalance(str10);
        sw.Stop();

        // In kết quả
        if (result10 == -1) Console.WriteLine("Kết quả: HOP LE");
        else Console.WriteLine($"Kết quả: SAI tai vi tri {result10}");
        Console.WriteLine($"Thời gian chạy: {sw.ElapsedMilliseconds} ms (Yêu cầu < 1000 ms)");

    }
}