using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace btvn_hangdoi_stack
{
    public class TwoStackQueue<T>
    {
        //tao ngan nhan
        private Stack<T> inbox = new Stack<T>();
        //tao ngan lay ra
        private Stack<T> outbox = new Stack<T>();
        //bien dem tong so lan chuyen giua 2 ngan
        public long transfers { get; private set; } = 0;
        //bien dem tong so phan tu trong 2 ngan
        public int Count => inbox.Count + outbox.Count;


        public void Enqueue(T value)
        {
            //them nguoi moi vao inbox
            inbox.Push(value);
        }

        public T Dequeue()
        {
            if (Count ==0)
            {
                throw new InvalidOperationException("Hang doi rong");

            }
            // xem trong outbox con phan tu khong roi moi chuyen tu inbox sang outbox
            if(outbox.Count == 0)
            {
                //lay het phan tu trong inbox qua outbox
                while (inbox.Count > 0)
                {
                    outbox.Push(inbox.Pop());
                    transfers++;
                }
            }

            return outbox.Pop();
        }
    }
    public class NaiveTwoStack<T>
    {
        private Stack<T> main = new Stack<T>();
        private Stack<T> temp = new Stack<T>();

        public void Enqueue(T value)
        {
            while (main.Count > 0) temp.Push(main.Pop());
            main.Push(value);
            while (temp.Count > 0) main.Push(temp.Pop());
        }

        public T Dequeue()
        {
            if (main.Count == 0) throw new InvalidOperationException("Hang doi rong");
            return main.Pop();
        }
    }
    public class bai4a
    {
        public static void Main(string[] args)
        {
            // 1. CA KIỂM THỬ BẮT BUỘC[cite: 1]
            Console.WriteLine("=== CA KIEM THU BAT BUOC ===");
            var q = new TwoStackQueue<int>();

            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);
            Console.WriteLine($"Lay ra: {q.Dequeue()} (Mong doi: 1)");

            q.Enqueue(4);
            Console.WriteLine($"Lay ra: {q.Dequeue()} (Mong doi: 2)");
            Console.WriteLine($"Lay ra: {q.Dequeue()} (Mong doi: 3)");
            Console.WriteLine($"Lay ra: {q.Dequeue()} (Mong doi: 4)");
            Console.WriteLine($"So lan chuyen (transfers): {q.transfers} (Mong doi: 4)\n");

            // 2. CA LỚN: 1 TRIỆU PHẦN TỬ[cite: 1]
            Console.WriteLine("=== CA LON (1 TRIEU PHAN TU) ===");
            var bigQ = new TwoStackQueue<int>();
            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < 1000000; i++) bigQ.Enqueue(i);
            for (int i = 0; i < 1000000; i++) bigQ.Dequeue();
            sw.Stop();
            Console.WriteLine($"So lan chuyen (transfers): {bigQ.transfers} (Mong doi: 1000000)");
            Console.WriteLine($"Thoi gian chay: {sw.ElapsedMilliseconds} ms (Mong doi < 1 giay)\n");

            // 3. ĐO THỜI GIAN SO SÁNH (ĐIỀN BẢNG 6)[cite: 1]
            Console.WriteLine("=== SO SANH HIEU SUAT (BANG 6) ===");
            int[] testSizes = { 1000, 5000, 20000 };
            Console.WriteLine("n\t|\tNaiveTwoStack (ms)\t|\tTwoStackQueue (ms)");
            Console.WriteLine("------------------------------------------------------------------");

            foreach (int n in testSizes)
            {
                // Đo thời gian bản chạy chậm (Naive)[cite: 1]
                var naive = new NaiveTwoStack<int>();
                Stopwatch sw1 = Stopwatch.StartNew();
                for (int i = 0; i < n; i++) naive.Enqueue(i);
                for (int i = 0; i < n; i++) naive.Dequeue();
                sw1.Stop();

                // Đo thời gian bản chạy nhanh của bạn (TwoStackQueue)[cite: 1]
                var smart = new TwoStackQueue<int>();
                Stopwatch sw2 = Stopwatch.StartNew();
                for (int i = 0; i < n; i++) smart.Enqueue(i);
                for (int i = 0; i < n; i++) smart.Dequeue();
                sw2.Stop();

                Console.WriteLine($"{n}\t|\t{sw1.ElapsedMilliseconds} ms\t\t\t|\t{sw2.ElapsedMilliseconds} ms");
            }
        }
    }
}
