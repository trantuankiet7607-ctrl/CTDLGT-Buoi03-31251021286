# btvn_hangdoi_stack
# CTDLGT-Buoi03-31251021286

## Thông tin sinh viên
- **Họ tên:** Trần Tuấn Kiệt
- **Mã số sinh viên:** 31251021286
- **Môn học:** Cấu trúc dữ liệu và Giải thuật
- **Giảng viên:** TS. Nguyễn Thành Huy

## Mục tiêu bài thực hành
Buổi thực hành 03 tập trung vào việc cài đặt và ứng dụng các cấu trúc dữ liệu Ngăn xếp (Stack) và Hàng đợi (Queue) bằng ngôn ngữ C#. 

Dự án này bao gồm các bài toán:
- Kiểm tra tính hợp lệ của chuỗi dấu ngoặc (Bài 1).
- Mô phỏng hệ thống xếp hàng chờ tại quầy dịch vụ (Bài 2).
- Tự cài đặt cấu trúc Hàng đợi vòng (Circular Queue) bằng mảng tĩnh (Bài 3).
- Cài đặt Hàng đợi sử dụng hai Ngăn xếp (Bài 4a - Thử thách).

## Hướng dẫn biên dịch và chạy chương trình

Dự án được viết trên nền tảng .NET (C#). Để chạy chương trình:
1.  Mở solution/project tương ứng trong **Visual Studio** hoặc **Visual Studio Code**.
2.  Đảm bảo đã cài đặt .NET SDK (phiên bản 6.0 trở lên).
3.  Chọn project cần chạy làm Startup Project.
4.  Nhấn `F5` hoặc nút `Start` để chạy (hoặc dùng lệnh `dotnet run` trong Terminal).

## Tóm tắt nội dung các bài tập

### Bài 1: Kiểm tra dấu ngoặc cân bằng
- **Giải pháp:** Sử dụng `Stack<(char ch, int pos)>` để lưu trữ các dấu ngoặc mở và vị trí của chúng. Khi gặp ngoặc đóng, kiểm tra với phần tử trên đỉnh Stack.
- **Độ phức tạp:**
  - Thời gian: $\Theta(n)$ với n là độ dài chuỗi (mỗi ký tự được xử lý 1 lần).
  - Không gian: $O(n)$ trong trường hợp xấu nhất (toàn ngoặc mở).

### Bài 2: Mô phỏng quầy dịch vụ
- **Giải pháp:** Dùng `Queue<Customer>` để lưu trữ khách hàng (vào trước ra trước). Dùng một mảng lưu thời điểm rảnh của các quầy và tìm quầy rảnh sớm nhất cho khách tiếp theo.
- **Độ phức tạp:**
  - Thời gian: $\Theta(n 	imes k)$ (n khách hàng, mỗi khách tìm quầy rảnh trong k quầy).
  - Không gian: $\Theta(n + k)$.

### Bài 3: Tự cài đặt Hàng đợi vòng (Circular Queue)
- **Giải pháp:** Dùng một mảng tĩnh. Sử dụng kỹ thuật chia lấy dư (`%`) để quản lý chỉ số `front` lộn vòng, giúp tận dụng tối đa không gian mảng. Tự động cấp phát mảng gấp đôi khi đầy.
- **Độ phức tạp:**
  - Thời gian: Enqueue là $\Theta(1)$ khấu hao (thỉnh thoảng tốn $\Theta(n)$ để mở rộng mảng); Dequeue là $\Theta(1)$.
  - Không gian: $\Theta(Capacity)$.

### Bài 4 (Phương án A): Hàng đợi bằng 2 Ngăn xếp
- **Giải pháp:** Dùng 2 Stack: `inbox` (nhận dữ liệu vào) và `outbox` (lấy dữ liệu ra). Chỉ chuyển dữ liệu từ `inbox` sang `outbox` khi `outbox` đã rỗng.
- **Độ phức tạp:**
  - Thời gian: Enqueue là $\Theta(1)$; Dequeue là $\Theta(1)$ khấu hao. (Nhanh hơn cách làm ngây ngô tốn $\Theta(n^2)$).
  - Không gian: $\Theta(n)$.

## Kết quả thực nghiệm các ca lớn

| Bài tập | Kích thước dữ liệu | Thời gian chạy mong đợi | Thời gian thực tế đo được |
| :--- | :--- | :--- | :--- |
| **Bài 1** | 1.000.000 ký tự | < 1 giây | *~[Ghi vào đây] ms* |
| **Bài 2** | 100.000 khách, 10 quầy | < 1 giây | *~[Ghi vào đây] ms* |
| **Bài 3** | 100.000 phần tử | < 1 giây | *~[Ghi vào đây] ms* |
| **Bài 4a**| 1.000.000 phần tử | < 1 giây | *~[Ghi vào đây] ms* |

*Chi tiết các bảng kiểm thử và ảnh chụp màn hình vui lòng xem trong file báo cáo Word đính kèm.*

## Khai báo sử dụng AI
Tôi đã sử dụng **Google Gemini** để hỗ trợ tạo khung báo cáo (README, cấu trúc giải thích), gợi ý cách tối ưu thuật toán cho bài Hàng đợi vòng (Bài 3) và Hai ngăn xếp (Bài 4a). Phần mã nguồn cuối cùng đã được tôi tự đọc hiểu, kiểm thử, tinh chỉnh và chịu trách nhiệm hoàn toàn về kết quả bài nộp.
