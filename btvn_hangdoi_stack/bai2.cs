using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;

namespace btvn_hangdoi_stack
{
    public class bai2
    {
        // tạo class customer
        public class Customer
        {
            public int Id;
            public long Arrival;
            public long Service;
        }

        public static void Main2(string[] args)
        {
            // đọc input
            string[] input = Console.ReadLine().Split(" ");
            int n = int.Parse(input[0]);
            int k = int.Parse(input[1]);
            Queue<Customer> q = new Queue<Customer>();

            // Đọc thông tin khách hàng rồi thêm vào queue
            for (int i = 1; i <= n; i++)
            {
                string[] addin4 = Console.ReadLine().Split(" ");
                q.Enqueue(new Customer
                {
                    Id = i,
                    Arrival = long.Parse(addin4[0]),
                    Service = long.Parse(addin4[1])
                });
            }

            // tạo mảng lưu thời điểm rảnh của k quầy
            long[] freetime = new long[k];
            long totalwait = 0, maxwait = 0, endtime = 0;

            // tạo vòng lặp (khi nào hết khách trong queue thì dừng)
            while (q.Count > 0)
            {
                // lấy từng khách hàng ra theo FIFO
                Customer c = q.Dequeue();

                // tìm quầy rảnh sớm nhất
                int bestquay = 0;
                // Sửa lỗi 1: i < k (không phải i <= k)
                for (int i = 1; i < k; i++)
                {
                    if (freetime[i] < freetime[bestquay])
                    {
                        bestquay = i;
                    }
                }

                // tính toán thời gian
                long batdau = Math.Max(c.Arrival, freetime[bestquay]);

                // Sửa lỗi 2: Viết đúng phép trừ trên 1 dòng
                long cho = batdau - c.Arrival;

                long xong = batdau + c.Service;

                // Sửa lỗi 3: Cập nhật lại thời gian rảnh vào sổ freetime
                freetime[bestquay] = xong;

                // Sửa lỗi 4: Cộng dồn totalwait (dùng +=)
                totalwait += cho;

                if (cho > maxwait) maxwait = cho;
                if (xong > endtime) endtime = xong;

                // in ra thông tin của khách hiện tại (In BAT DAU chứ không in BIẾN)
                // Lưu ý nhỏ: Bài này yêu cầu in số quầy bắt đầu từ 1, nên bestquay + 1 là đúng
                Console.WriteLine($"KH {c.Id}: den {c.Arrival}, quay {bestquay + 1}, bat dau {batdau}, cho {cho}, xong {xong}");
            }

            // Sửa lỗi 5: Phần tổng kết phải NẰM NGOÀI vòng lặp while
            double avgWait = (double)totalwait / n;
            Console.WriteLine($"Cho trung binh: {avgWait.ToString("F2", CultureInfo.InvariantCulture)}");
            Console.WriteLine($"Cho lau nhat: {maxwait}");
            Console.WriteLine($"Hoan thanh luc: {endtime}");

            // case 6
            Console.WriteLine("\n--- BAT DAU CHAY CA KIEM THU 6 (100.000 KHACH) ---");

            // Tự động sinh dữ liệu 100.000 khách theo đề bài[cite: 1]
            int n6 = 100000;
            int k6 = 10;
            Queue<Customer> q6 = new Queue<Customer>();

            for (int i = 1; i <= n6; i++)
            {
                q6.Enqueue(new Customer
                {
                    Id = i,
                    Arrival = i - 1,
                    Service = 10
                });
            }

            long[] freetime6 = new long[k6];
            long totalwait6 = 0, maxwait6 = 0, endtime6 = 0;

            // Bắt đầu bấm giờ
            Stopwatch sw = Stopwatch.StartNew();

            while (q6.Count > 0)
            {
                Customer c = q6.Dequeue();
                int bestquay = 0;
                for (int i = 1; i < k6; i++)
                {
                    if (freetime6[i] < freetime6[bestquay])
                    {
                        bestquay = i;
                    }
                }

                long batdau = Math.Max(c.Arrival, freetime6[bestquay]);
                long cho = batdau - c.Arrival;
                long xong = batdau + c.Service;

                freetime6[bestquay] = xong;
                totalwait6 += cho;
                if (cho > maxwait6) maxwait6 = cho;
                if (xong > endtime6) endtime6 = xong;

                // Không in chi tiết từng khách để đo thời gian cho chuẩn
            }

            sw.Stop(); // Dừng bấm giờ

            // In kết quả Test case 6
            double avgWait6 = (double)totalwait6 / n6;
            Console.WriteLine($"Cho trung binh: {avgWait6.ToString("F2", CultureInfo.InvariantCulture)}");
            Console.WriteLine($"Cho lau nhat: {maxwait6}");
            Console.WriteLine($"Hoan thanh luc: {endtime6}");
            Console.WriteLine($"=> THOI GIAN CHAY THUC TE: {sw.ElapsedMilliseconds} ms (Yeu cau < 1000 ms)");
        }
    }
}