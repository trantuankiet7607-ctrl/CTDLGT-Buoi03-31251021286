using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace btvn_hangdoi_stack
{
    //tạo class hàng đợi
    public class CircularQueue<T>
    {
        // mang items chua cac gia tri nhap vao
        private T[] items;
        // front luu vi tri phantu dung dau
        private int front;

        public int count { get; private set; }

        //suc chua cua hang doi
        public int capacity => items.Length;

        public CircularQueue()
        {
            items = new T[4];
            front = 0;
            count = 0;
        }
        // tao chuc nang Enqueue
        public void Enqueue(T value)
        {
            //hang doi het cho
            if (count == capacity)
            {
                //tao hang moi co suc chua gap doi
                T[] newitems = new T[2 * capacity];
                for (int i = 0; i < count; i++)
                {
                    // Dùng (front + i) % Capacity để nhặt đúng người theo thứ tự từ đầu hàng đến cuối hàng.
                    newitems[i] = items[(i + count) % capacity];

                }
                //mang moi thay the mang cu
                items = newitems;
                front = 0;
            }
            //phần tử cuối nằm ở ô front + count + 1 và khi thêm 1 phần tử sẽ ở vị trí front + count
            // % capacity dùng để nếu hết chỗ ở cuối thì quay về khoảng trống ở đầu.
            int rear = (front + count) % capacity;
            items[rear] = value;
            count++;

        }
        public T dequeue()
        {
            //Kiem tra trong queue con phan tu hay khong
            if (count ==0)
            {
                throw new InvalidOperationException("hang doi rong, khong the dequeqe");

            }
            // luu gia tri lay ra
            T value = items[front];
            //xoa gia tri lay ra
            items[front] = default;
            // gia tri dang sau thanh front
            front = (front + 1) % capacity;
            count--;
            //tra ve gia tri lay ra
            return value;
        }
        public T peek()
        {
            //Kiem tra trong queue con phan tu hay khong
            if (count == 0)
            {
                throw new InvalidOperationException("hang doi rong, khong the peek");

            }
            return items[front];
        }
    }
    public class bai3
    {
        public static void Main3(string[] args)
        {
            Console.WriteLine("=== CHAY 7 CA KIEM THU BAI 3 ===");

            // Ca 1: Hàng rỗng[cite: 1]
            Console.WriteLine("\n[Ca 1] Hang rong:");
            var q1 = new CircularQueue<int>();
            Console.WriteLine($"Count: {q1.count}, Capacity: {q1.capacity}");
            try { q1.dequeue(); } catch (Exception e) { Console.WriteLine($"Loi Dequeue: {e.GetType().Name}"); }
            try { q1.peek(); } catch (Exception e) { Console.WriteLine($"Loi Peek: {e.GetType().Name}"); }

            // Ca 2: Vừa đầy[cite: 1]
            Console.WriteLine("\n[Ca 2] Vua day:");
            var q2 = new CircularQueue<string>();
            q2.Enqueue("A"); q2.Enqueue("B"); q2.Enqueue("C"); q2.Enqueue("D");
            Console.WriteLine($"Count: {q2.count}, Capacity: {q2.capacity}");
            Console.WriteLine($"Peek: {q2.peek()}");

            // Ca 3: Quay vòng chỉ số, chưa mở rộng[cite: 1]
            Console.WriteLine("\n[Ca 3] Quay vong chi so, chua mo rong:");
            var q3 = new CircularQueue<string>();
            q3.Enqueue("A"); q3.Enqueue("B"); q3.Enqueue("C"); q3.Enqueue("D");
            Console.Write($"Lay ra: {q3.dequeue()}, {q3.dequeue()} | ");
            q3.Enqueue("E"); q3.Enqueue("F");
            Console.Write($"{q3.dequeue()}, {q3.dequeue()}, {q3.dequeue()}, {q3.dequeue()}");
            Console.WriteLine($"\nCapacity cuoi cung: {q3.capacity}");

            // Ca 4: Mở rộng khi front = 0[cite: 1]
            Console.WriteLine("\n[Ca 4] Mo rong khi front = 0:");
            var q4 = new CircularQueue<int>();
            q4.Enqueue(1); q4.Enqueue(2); q4.Enqueue(3); q4.Enqueue(4); q4.Enqueue(5);
            Console.WriteLine($"Capacity hien tai: {q4.capacity}");
            Console.Write($"Lay ra: {q4.dequeue()}, {q4.dequeue()}, {q4.dequeue()}, {q4.dequeue()}, {q4.dequeue()}\n");

            // Ca 5: Mở rộng khi front khác 0[cite: 1]
            Console.WriteLine("\n[Ca 5] Mo rong khi front khac 0:");
            var q5 = new CircularQueue<string>();
            q5.Enqueue("A"); q5.Enqueue("B"); q5.Enqueue("C"); q5.Enqueue("D");
            q5.dequeue(); q5.dequeue();
            q5.Enqueue("E"); q5.Enqueue("F"); q5.Enqueue("G");
            Console.WriteLine($"Capacity hien tai: {q5.capacity}");
            Console.Write($"Lay ra: {q5.dequeue()}, {q5.dequeue()}, {q5.dequeue()}, {q5.dequeue()}, {q5.dequeue()}\n");

            // Ca 6: Lặp quay vòng rất nhiều lần[cite: 1]
            Console.WriteLine("\n[Ca 6] 1.000.000 lan Enqueue roi Dequeue:");
            var q6 = new CircularQueue<int>();
            for (int i = 0; i < 1000000; i++)
            {
                q6.Enqueue(i);
                q6.dequeue();
            }
            Console.WriteLine($"Khong loi. Capacity cuoi cung: {q6.capacity}");

            // Ca 7: Ca lớn, kiểm tra hiệu suất mở rộng mảng[cite: 1]
            Console.WriteLine("\n[Ca 7] Nhieu lan mo rong (100.000 phan tu):");
            var q7 = new CircularQueue<int>();
            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < 100000; i++) q7.Enqueue(i);
            for (int i = 0; i < 100000; i++) q7.dequeue();
            sw.Stop();
            Console.WriteLine($"Capacity cuoi: {q7.capacity}");
            Console.WriteLine($"Thoi gian chay: {sw.ElapsedMilliseconds} ms (Mong doi < 1 giay)");
        }
    }
}
