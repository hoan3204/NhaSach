using Microsoft.AspNetCore.Identity;
using NhaSachAdmin.ChucNangPhanQuyen;

namespace NhaSachAdmin.Data
{
    public class DataSeed
    {
        public static async Task KhoiTaoDuLieuMacDinh(IServiceProvider dichVu)
        {
            var quanLyNguoiDung = dichVu.GetService<UserManager<IdentityUser>>();
            var quanLyVaiTro = dichVu.GetService<RoleManager<IdentityRole>>();

            //them 1 vai tro vao csdl
            await quanLyVaiTro.CreateAsync(new IdentityRole(PhanQuyen.Admin.ToString()));
            await quanLyVaiTro.CreateAsync(new IdentityRole(PhanQuyen.User.ToString()));

                      //tao thong tin mac dinh cho tk admin
                         //username, email, xac thuc email
                var quanTri = new IdentityUser
                {
                    UserName = "testadmin@gmail.com",
                    Email = "testadmin@gmail.com",
                    EmailConfirmed = true
                };
            var nguoiDungTrongCSDL = await quanLyNguoiDung.FindByEmailAsync(quanTri.Email);
//neu tk k ton tai trong csdl
            if (nguoiDungTrongCSDL == null)
            {
                var ketqua = await quanLyNguoiDung.CreateAsync(quanTri, "Hoan12345@");
                //await quanLyNguoiDung.AddToRoleAsync(quanTri, PhanQuyen.Admin.ToString());
                if (ketqua.Succeeded)
                {
                    await quanLyNguoiDung.AddToRoleAsync(quanTri, PhanQuyen.Admin.ToString());
                }
            }
        }
    }
}
