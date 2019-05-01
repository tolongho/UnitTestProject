using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using ProjectMyself.Controllers;
using System.Web.Mvc;
using ProjectMyself.Models;
using System.Collections.Generic;

namespace ProjectMyself.Tests.Controllers
{
    [TestClass]
    public class BubleTeasControllerTest
    {
        [TestMethod]
        public void TestIndex()
        {
            // Khai báo Controller
            BubleTeasController controller = new BubleTeasController();

            // Khai báo result = view, ép kiểu Index of Controller thành ViewResult
            ViewResult result = controller.Index() as ViewResult;

            // Kiểm tra có load View không?
            Assert.IsNotNull(result);

            // Khai báo model và database
            var model = result.Model as List<BubleTea>;
            var db = new CS4PEEntities();

            // Kiểm tra có phải là model không?
            Assert.IsNotNull(result);

            // Kiểm tra có load đủ danh sách model không?
            Assert.AreEqual(db.BubleTeas.Count(), model.Count());

        }

        [TestMethod]
        public void TestDetails()
        {
            // Khai báo Controller
            var controller = new BubleTeasController();

            // Khai báo 1 giá trị không tồn tại
            var result0 = controller.Details(0);

            // Kiểm tra khi không có giá trị thì có -> lỗi Http
            Assert.IsInstanceOfType(result0, typeof(HttpNotFoundResult));

            // Khai báo database
            var db = new CS4PEEntities();

            // Lấy giá trị đầu tiên từ database
            var item = db.BubleTeas.First();

            // Khai báo giá trị đầu tiên kiểu view
            var result1 = controller.Details(item.id) as ViewResult;

            // Kiểm tra có load được View?
            Assert.IsNotNull(result1);

            // Khai báo model
            var model = result1.Model as BubleTea;

            // Kiểm tra có phải Model?
            Assert.IsNotNull(model);

            // Kiểm tra có load đúng item.id = model.id
            Assert.AreEqual(item.id, model.id);

        }

        [TestMethod]
        public void TestCreateGet()
        {
            // Khai báo Controller
            var controller = new BubleTeasController();

            // Khai báo View Create
            var result = controller.Create() as ViewResult;

            // Kiểm tra có phải View?
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestCreatePost()
        {
            // Khai báo Controller
            var controller = new BubleTeasController();

            // Khai báo model, cho giá trị vào model
            var model = new BubleTea
            {
                Name = "Tra Sua Vi Cam",
                Price = 50000,
                Topping = "Tran Chau Cam"
            };

            ///////// Lỗi model không xuống database được

            // Khai báo database
            var db = new CS4PEEntities();

            // Khai báo item, và tìm model vừa truyền vào = item
            var item = db.BubleTeas.Find(model.id);

            // Kiểm tra item có trong database chưa?
            Assert.IsNotNull(item);

            // Kiểm tra tên, giá và hạt có giống nhau không?
            Assert.AreEqual(model.Name, item.Name);
            Assert.AreEqual(model.Price, item.Price);
            Assert.AreEqual(model.Topping, item.Topping);

            // Khai váo kết quả Result = Create(model)
            var result = controller.Create(model);

            // Khai báo chuyển hướng và ép Result thành chuyển hướng
            var redirect = result as RedirectToRouteResult;

            // Kiểm tra có đúng là Redirect
            Assert.IsNotNull(redirect);

            // Kiểm tra có trả về đúng trang Index
            Assert.AreEqual("Index", redirect.RouteValues["action"]);
        }

        [TestMethod]
        public void TestEditGet()
        {
            // Khai báo Controller
            var controller = new BubleTeasController();

            // Khai báo 1 giá trị không tồn tại
            var result0 = controller.Edit(0);

            // Kiểm tra khi không có giá trị thì có -> lỗi Http
            Assert.IsInstanceOfType(result0, typeof(HttpNotFoundResult));

            // Khai báo database
            var db = new CS4PEEntities();

            // Lấy giá trị đầu tiên từ database
            var item = db.BubleTeas.First();

            // Khai báo giá trị đầu tiên kiểu view
            var result1 = controller.Edit(item.id) as ViewResult;

            // Kiểm tra có load được View?
            Assert.IsNotNull(result1);

            // Khai báo model
            var model = result1.Model as BubleTea;

            // Kiểm tra có phải Model?
            Assert.IsNotNull(model);

            // Kiểm tra có load đúng item.id = model.id
            Assert.AreEqual(item.id, model.id);

        }

        [TestMethod]
        public void TestEditPost()
        {
            // Khai báo Controller
            var controller = new BubleTeasController();

            // Khai báo database 
            var db = new CS4PEEntities();

            // Lấy giá trị đầu tiên từ database
            var item = db.BubleTeas.First();

            // Khai báo giá trị đầu tiên kiểu view
            var result1 = controller.Edit(item.id) as ViewResult;

            // Kiểm tra có load được View?
            Assert.IsNotNull(result1);

            // Khai báo model
            var model = result1.Model as BubleTea;

            // Kiểm tra có phải Model?
            Assert.IsNotNull(model);

            // Khai váo kết quả Result = Create(model)
            var result = controller.Edit(model);

            // Khai báo chuyển hướng và ép Result thành chuyển hướng
            var redirect = result as RedirectToRouteResult;

            // Kiểm tra có đúng là Redirect
            Assert.IsNotNull(redirect);

            // Kiểm tra có trả về đúng trang Index
            Assert.AreEqual("Index", redirect.RouteValues["action"]);

        }

        [TestMethod]
        public void TestDeleteGet()
        {
            // Khai báo Controller
            var controller = new BubleTeasController();

            // Khai báo 1 giá trị không tồn tại
            var result0 = controller.Delete(0);

            // Kiểm tra khi không có giá trị thì có -> lỗi Http
            Assert.IsInstanceOfType(result0, typeof(HttpNotFoundResult));

            // Khai báo database
            var db = new CS4PEEntities();

            // Lấy giá trị đầu tiên từ database
            var item = db.BubleTeas.First();

            // Khai báo giá trị đầu tiên kiểu view
            var result1 = controller.Delete(item.id) as ViewResult;

            // Kiểm tra có load được View?
            Assert.IsNotNull(result1);

            // Khai báo model
            var model = result1.Model as BubleTea;

            // Kiểm tra có phải Model?
            Assert.IsNotNull(model);

            // Kiểm tra có load đúng item.id = model.id
            Assert.AreEqual(item.id, model.id);

        }

        [TestMethod]
        public void TestDeletePost()
        {
            // Không thể tìm được models

        }
    }
}
