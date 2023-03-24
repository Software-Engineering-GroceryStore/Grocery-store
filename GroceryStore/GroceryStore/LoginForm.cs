using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GroceryStore
{
    public partial class LoginForm : Form
    {
        String connectionString = "Data Source=DESKTOP-RTQDFRG\\SQLEXPRESS;Initial Catalog=CuaHangTienLoi;Integrated Security=True";

        public LoginForm()
        {
            InitializeComponent();

            // Đặt kiểu phẳng của button thành Popup
            btn_login.FlatStyle = FlatStyle.Flat;

            // Đặt bán kính của góc bo thành 80
            btn_login.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_login.Width, btn_login.Height, 12, 12));
        }

        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern System.IntPtr CreateRoundRectRgn(int x1, int y1, int x2, int y2, int cx, int cy);


        private void tb_password_TextChanged(object sender, EventArgs e)
        {
            if (tb_password.Text.Length < 8)
            {
                errorLogin.SetError(tb_password, "Mật khẩu phải có ít nhất 8 kí tự");
            }
            else if (tb_password.Text.Equals(""))
            {
                errorLogin.SetError(tb_password, "Mật khẩu không được bỏ trống");
            }
            else
            {
                errorLogin.SetError(tb_password, "");
            }
        }

        private void tb_sdt_TextChanged(object sender, EventArgs e)
        {
            // Kiểm tra nếu tb_sdt chứa kí tự là chữ
            if (Regex.IsMatch(tb_sdt.Text, "[a-zA-Z]"))
            {
                errorLogin.SetError(tb_sdt, "Số điện thoại không được chứa kí tự là chữ");
            }
            else if (tb_sdt.Text.Length < 10 || tb_sdt.Text.Length > 10)
            {
                errorLogin.SetError(tb_sdt, "Số điện thoại không đúng định dạng");
            }
            else
            {
                errorLogin.SetError(tb_sdt, "");
            }
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            string sdt, password;
            connectDB(out sdt, out password);

            // Sau khi gọi hàm connectDB, sdt và password sẽ chứa giá trị trả về từ câu lệnh SQL.


            if (errorLogin.GetError(tb_sdt) != "" || errorLogin.GetError(tb_sdt) != "")
            {
                lb_error.Text = "Vui lòng kiểm tra lại thông tin";
            }
            else
            {
                //nếu mật khẩu và tài khoản đúng, xử lý ở đây
                if (sdt == tb_sdt.Text && password == tb_password.Text)
                {
                    MessageBox.Show("Đông ngooo");
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại");
                }
            }
        }



        private void connectDB(out string sdt, out string password)
        {
            // Kết nối đến database
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Tạo command để thực thi stored procedure
                SqlCommand cmd = new SqlCommand("checkLogin", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm tham số vào command
                SqlParameter param = new SqlParameter("@SoDienThoai", SqlDbType.VarChar);
                param.Value = tb_sdt.Text;
                cmd.Parameters.Add(param);

                // Mở kết nối
                conn.Open();

                // Thực thi command và đọc dữ liệu trả về
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    // Lấy các giá trị trả về từ reader
                    sdt = reader.GetString(reader.GetOrdinal("SoDienThoai"));
                    password = reader.GetString(reader.GetOrdinal("MatKhau"));
                }
                else
                {
                    // Không tìm thấy dữ liệu, gán giá trị mặc định cho sdt và password
                    sdt = "";
                    password = "";
                }
            }
        }
        private void lb_forgetPassword_Click(object sender, EventArgs e)
        {
            //xử lý sự kiện forgot password


        }

        private void lb_signUp_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
        }
    }
}