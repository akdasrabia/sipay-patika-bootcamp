using Microsoft.AspNetCore.Mvc;

namespace odev1.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BlogController : ControllerBase
    {
        private static List<Blog> BlogList = new List<Blog>()
        {
            new Blog
            {
                Id = 1,
                Title = "Test",
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In pulvinar tortor sed elit commodo, id convallis arcu tincidunt. Pellentesque pretium dignissim molestie. Etiam sit amet ornare risus. Donec rhoncus eu leo vel dictum. Maecenas ac velit eu felis porttitor ullamcorper vitae id massa. Proin tortor eros, porta ut ultricies consequat, bibendum sed lorem. Praesent nunc arcu, iaculis eu neque a, luctus fringilla sapien. Vestibulum ullamcorper fermentum ex, vel congue velit pellentesque non. Donec eu nibh vitae enim eleifend aliquet. Nam varius mi ac sapien consequat dapibus nec ut tellus. Sed molestie aliquam felis, vitae luctus sapien. Nullam feugiat arcu in massa semper, sed vulputate ex placerat.\r\n\r\nDonec non dui sit amet leo eleifend maximus. Suspendisse pretium, dolor vel rutrum mattis, tellus diam eleifend turpis, eu auctor orci odio non neque. Integer gravida tortor at convallis aliquam. Nam at mauris id magna elementum lacinia nec ac nulla. Maecenas pellentesque rutrum dapibus. Quisque ornare blandit pretium. Ut quis libero justo. Curabitur dictum feugiat diam sit amet facilisis. Pellentesque eget convallis tortor. Aenean volutpat malesuada lectus, non fermentum neque maximus sed. Cras fermentum erat id lacinia semper. Ut sapien velit, tempus a pharetra vitae, gravida placerat tellus. Quisque molestie, dui ac gravida dapibus, urna ipsum porta purus, ac fermentum sem purus gravida enim. Suspendisse potenti. Aliquam erat orci, vestibulum ac nisl non, bibendum suscipit enim. In et lorem mollis, egestas leo vitae, eleifend dolor.\r\n\r\nQuisque sollicitudin ipsum id justo fringilla, a tincidunt erat sodales. Donec tristique malesuada porttitor. Maecenas aliquam nulla vel elit condimentum, sed tempus arcu porttitor. Donec vel velit nisi. Nullam non tempus augue. Mauris augue purus, sodales et risus eu, volutpat auctor erat. Nullam commodo vitae velit vel iaculis. Donec egestas est ac massa ultrices convallis. Praesent sed sodales enim.\r\n\r\nPellentesque egestas fringilla mi, at mattis quam laoreet sed. Duis egestas auctor lectus, sed bibendum mauris vehicula sit amet. Donec a dolor nunc. Donec in tincidunt turpis. Suspendisse potenti. Phasellus ut neque nec tortor dignissim suscipit eu et purus. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Cras condimentum lectus eget lacus semper, vel aliquet magna maximus. Aenean efficitur euismod felis eget tempor. Quisque sagittis dui orci, nec molestie ante aliquam et. Etiam ut sem sagittis, congue metus sed, efficitur nisl. Sed viverra pulvinar ex quis volutpat. Praesent rutrum sem risus, sed tempus urna luctus eget.\r\n\r\nMauris non urna eleifend, fermentum nunc et, pellentesque urna. Aenean vehicula, urna non pellentesque aliquet, est massa ornare odio, id tincidunt enim metus id libero. Nullam dictum elementum sapien, condimentum tincidunt odio sodales non. Etiam porttitor condimentum lobortis. Ut varius interdum bibendum. Quisque commodo iaculis sagittis. Cras in lorem nec eros placerat commodo eget vel eros. Proin at nibh ex. Etiam sit amet erat metus. Quisque fermentum turpis non tortor congue, a bibendum ligula congue. Duis ante risus, hendrerit pharetra tortor eu, cursus venenatis odio.",
                CreatedAt = new DateTime(2023, 01,12),
            },
            new Blog {
                Id = 2,
                Title = "Test",
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In pulvinar tortor sed elit commodo, id convallis arcu tincidunt. Pellentesque pretium dignissim molestie. Etiam sit amet ornare risus. Donec rhoncus eu leo vel dictum. Maecenas ac velit eu felis porttitor ullamcorper vitae id massa. Proin tortor eros, porta ut ultricies consequat, bibendum sed lorem. Praesent nunc arcu, iaculis eu neque a, luctus fringilla sapien. Vestibulum ullamcorper fermentum ex, vel congue velit pellentesque non. Donec eu nibh vitae enim eleifend aliquet. Nam varius mi ac sapien consequat dapibus nec ut tellus. Sed molestie aliquam felis, vitae luctus sapien. Nullam feugiat arcu in massa semper, sed vulputate ex placerat.\r\n\r\nDonec non dui sit amet leo eleifend maximus. Suspendisse pretium, dolor vel rutrum mattis, tellus diam eleifend turpis, eu auctor orci odio non neque. Integer gravida tortor at convallis aliquam. Nam at mauris id magna elementum lacinia nec ac nulla. Maecenas pellentesque rutrum dapibus. Quisque ornare blandit pretium. Ut quis libero justo. Curabitur dictum feugiat diam sit amet facilisis. Pellentesque eget convallis tortor. Aenean volutpat malesuada lectus, non fermentum neque maximus sed. Cras fermentum erat id lacinia semper. Ut sapien velit, tempus a pharetra vitae, gravida placerat tellus. Quisque molestie, dui ac gravida dapibus, urna ipsum porta purus, ac fermentum sem purus gravida enim. Suspendisse potenti. Aliquam erat orci, vestibulum ac nisl non, bibendum suscipit enim. In et lorem mollis, egestas leo vitae, eleifend dolor.\r\n\r\nQuisque sollicitudin ipsum id justo fringilla, a tincidunt erat sodales. Donec tristique malesuada porttitor. Maecenas aliquam nulla vel elit condimentum, sed tempus arcu porttitor. Donec vel velit nisi. Nullam non tempus augue. Mauris augue purus, sodales et risus eu, volutpat auctor erat. Nullam commodo vitae velit vel iaculis. Donec egestas est ac massa ultrices convallis. Praesent sed sodales enim.\r\n\r\nPellentesque egestas fringilla mi, at mattis quam laoreet sed. Duis egestas auctor lectus, sed bibendum mauris vehicula sit amet. Donec a dolor nunc. Donec in tincidunt turpis. Suspendisse potenti. Phasellus ut neque nec tortor dignissim suscipit eu et purus. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Cras condimentum lectus eget lacus semper, vel aliquet magna maximus. Aenean efficitur euismod felis eget tempor. Quisque sagittis dui orci, nec molestie ante aliquam et. Etiam ut sem sagittis, congue metus sed, efficitur nisl. Sed viverra pulvinar ex quis volutpat. Praesent rutrum sem risus, sed tempus urna luctus eget.\r\n\r\nMauris non urna eleifend, fermentum nunc et, pellentesque urna. Aenean vehicula, urna non pellentesque aliquet, est massa ornare odio, id tincidunt enim metus id libero. Nullam dictum elementum sapien, condimentum tincidunt odio sodales non. Etiam porttitor condimentum lobortis. Ut varius interdum bibendum. Quisque commodo iaculis sagittis. Cras in lorem nec eros placerat commodo eget vel eros. Proin at nibh ex. Etiam sit amet erat metus. Quisque fermentum turpis non tortor congue, a bibendum ligula congue. Duis ante risus, hendrerit pharetra tortor eu, cursus venenatis odio.",
                CreatedAt = new DateTime(2023, 05,18),
            },
            new Blog {
                Id = 3,
                Title = "Test",
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In pulvinar tortor sed elit commodo, id convallis arcu tincidunt. Pellentesque pretium dignissim molestie. Etiam sit amet ornare risus. Donec rhoncus eu leo vel dictum. Maecenas ac velit eu felis porttitor ullamcorper vitae id massa. Proin tortor eros, porta ut ultricies consequat, bibendum sed lorem. Praesent nunc arcu, iaculis eu neque a, luctus fringilla sapien. Vestibulum ullamcorper fermentum ex, vel congue velit pellentesque non. Donec eu nibh vitae enim eleifend aliquet. Nam varius mi ac sapien consequat dapibus nec ut tellus. Sed molestie aliquam felis, vitae luctus sapien. Nullam feugiat arcu in massa semper, sed vulputate ex placerat.\r\n\r\nDonec non dui sit amet leo eleifend maximus. Suspendisse pretium, dolor vel rutrum mattis, tellus diam eleifend turpis, eu auctor orci odio non neque. Integer gravida tortor at convallis aliquam. Nam at mauris id magna elementum lacinia nec ac nulla. Maecenas pellentesque rutrum dapibus. Quisque ornare blandit pretium. Ut quis libero justo. Curabitur dictum feugiat diam sit amet facilisis. Pellentesque eget convallis tortor. Aenean volutpat malesuada lectus, non fermentum neque maximus sed. Cras fermentum erat id lacinia semper. Ut sapien velit, tempus a pharetra vitae, gravida placerat tellus. Quisque molestie, dui ac gravida dapibus, urna ipsum porta purus, ac fermentum sem purus gravida enim. Suspendisse potenti. Aliquam erat orci, vestibulum ac nisl non, bibendum suscipit enim. In et lorem mollis, egestas leo vitae, eleifend dolor.\r\n\r\nQuisque sollicitudin ipsum id justo fringilla, a tincidunt erat sodales. Donec tristique malesuada porttitor. Maecenas aliquam nulla vel elit condimentum, sed tempus arcu porttitor. Donec vel velit nisi. Nullam non tempus augue. Mauris augue purus, sodales et risus eu, volutpat auctor erat. Nullam commodo vitae velit vel iaculis. Donec egestas est ac massa ultrices convallis. Praesent sed sodales enim.\r\n\r\nPellentesque egestas fringilla mi, at mattis quam laoreet sed. Duis egestas auctor lectus, sed bibendum mauris vehicula sit amet. Donec a dolor nunc. Donec in tincidunt turpis. Suspendisse potenti. Phasellus ut neque nec tortor dignissim suscipit eu et purus. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Cras condimentum lectus eget lacus semper, vel aliquet magna maximus. Aenean efficitur euismod felis eget tempor. Quisque sagittis dui orci, nec molestie ante aliquam et. Etiam ut sem sagittis, congue metus sed, efficitur nisl. Sed viverra pulvinar ex quis volutpat. Praesent rutrum sem risus, sed tempus urna luctus eget.\r\n\r\nMauris non urna eleifend, fermentum nunc et, pellentesque urna. Aenean vehicula, urna non pellentesque aliquet, est massa ornare odio, id tincidunt enim metus id libero. Nullam dictum elementum sapien, condimentum tincidunt odio sodales non. Etiam porttitor condimentum lobortis. Ut varius interdum bibendum. Quisque commodo iaculis sagittis. Cras in lorem nec eros placerat commodo eget vel eros. Proin at nibh ex. Etiam sit amet erat metus. Quisque fermentum turpis non tortor congue, a bibendum ligula congue. Duis ante risus, hendrerit pharetra tortor eu, cursus venenatis odio.",
                CreatedAt = new DateTime(2023, 06,03),
            },
            new Blog {
                Id = 4,
                Title = "Test",
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In pulvinar tortor sed elit commodo, id convallis arcu tincidunt. Pellentesque pretium dignissim molestie. Etiam sit amet ornare risus. Donec rhoncus eu leo vel dictum. Maecenas ac velit eu felis porttitor ullamcorper vitae id massa. Proin tortor eros, porta ut ultricies consequat, bibendum sed lorem. Praesent nunc arcu, iaculis eu neque a, luctus fringilla sapien. Vestibulum ullamcorper fermentum ex, vel congue velit pellentesque non. Donec eu nibh vitae enim eleifend aliquet. Nam varius mi ac sapien consequat dapibus nec ut tellus. Sed molestie aliquam felis, vitae luctus sapien. Nullam feugiat arcu in massa semper, sed vulputate ex placerat.\r\n\r\nDonec non dui sit amet leo eleifend maximus. Suspendisse pretium, dolor vel rutrum mattis, tellus diam eleifend turpis, eu auctor orci odio non neque. Integer gravida tortor at convallis aliquam. Nam at mauris id magna elementum lacinia nec ac nulla. Maecenas pellentesque rutrum dapibus. Quisque ornare blandit pretium. Ut quis libero justo. Curabitur dictum feugiat diam sit amet facilisis. Pellentesque eget convallis tortor. Aenean volutpat malesuada lectus, non fermentum neque maximus sed. Cras fermentum erat id lacinia semper. Ut sapien velit, tempus a pharetra vitae, gravida placerat tellus. Quisque molestie, dui ac gravida dapibus, urna ipsum porta purus, ac fermentum sem purus gravida enim. Suspendisse potenti. Aliquam erat orci, vestibulum ac nisl non, bibendum suscipit enim. In et lorem mollis, egestas leo vitae, eleifend dolor.\r\n\r\nQuisque sollicitudin ipsum id justo fringilla, a tincidunt erat sodales. Donec tristique malesuada porttitor. Maecenas aliquam nulla vel elit condimentum, sed tempus arcu porttitor. Donec vel velit nisi. Nullam non tempus augue. Mauris augue purus, sodales et risus eu, volutpat auctor erat. Nullam commodo vitae velit vel iaculis. Donec egestas est ac massa ultrices convallis. Praesent sed sodales enim.\r\n\r\nPellentesque egestas fringilla mi, at mattis quam laoreet sed. Duis egestas auctor lectus, sed bibendum mauris vehicula sit amet. Donec a dolor nunc. Donec in tincidunt turpis. Suspendisse potenti. Phasellus ut neque nec tortor dignissim suscipit eu et purus. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Cras condimentum lectus eget lacus semper, vel aliquet magna maximus. Aenean efficitur euismod felis eget tempor. Quisque sagittis dui orci, nec molestie ante aliquam et. Etiam ut sem sagittis, congue metus sed, efficitur nisl. Sed viverra pulvinar ex quis volutpat. Praesent rutrum sem risus, sed tempus urna luctus eget.\r\n\r\nMauris non urna eleifend, fermentum nunc et, pellentesque urna. Aenean vehicula, urna non pellentesque aliquet, est massa ornare odio, id tincidunt enim metus id libero. Nullam dictum elementum sapien, condimentum tincidunt odio sodales non. Etiam porttitor condimentum lobortis. Ut varius interdum bibendum. Quisque commodo iaculis sagittis. Cras in lorem nec eros placerat commodo eget vel eros. Proin at nibh ex. Etiam sit amet erat metus. Quisque fermentum turpis non tortor congue, a bibendum ligula congue. Duis ante risus, hendrerit pharetra tortor eu, cursus venenatis odio.",
                CreatedAt = new DateTime(2023, 06,12),
            },
            new Blog {
                Id = 5,
                Title = "Test",
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In pulvinar tortor sed elit commodo, id convallis arcu tincidunt. Pellentesque pretium dignissim molestie. Etiam sit amet ornare risus. Donec rhoncus eu leo vel dictum. Maecenas ac velit eu felis porttitor ullamcorper vitae id massa. Proin tortor eros, porta ut ultricies consequat, bibendum sed lorem. Praesent nunc arcu, iaculis eu neque a, luctus fringilla sapien. Vestibulum ullamcorper fermentum ex, vel congue velit pellentesque non. Donec eu nibh vitae enim eleifend aliquet. Nam varius mi ac sapien consequat dapibus nec ut tellus. Sed molestie aliquam felis, vitae luctus sapien. Nullam feugiat arcu in massa semper, sed vulputate ex placerat.\r\n\r\nDonec non dui sit amet leo eleifend maximus. Suspendisse pretium, dolor vel rutrum mattis, tellus diam eleifend turpis, eu auctor orci odio non neque. Integer gravida tortor at convallis aliquam. Nam at mauris id magna elementum lacinia nec ac nulla. Maecenas pellentesque rutrum dapibus. Quisque ornare blandit pretium. Ut quis libero justo. Curabitur dictum feugiat diam sit amet facilisis. Pellentesque eget convallis tortor. Aenean volutpat malesuada lectus, non fermentum neque maximus sed. Cras fermentum erat id lacinia semper. Ut sapien velit, tempus a pharetra vitae, gravida placerat tellus. Quisque molestie, dui ac gravida dapibus, urna ipsum porta purus, ac fermentum sem purus gravida enim. Suspendisse potenti. Aliquam erat orci, vestibulum ac nisl non, bibendum suscipit enim. In et lorem mollis, egestas leo vitae, eleifend dolor.\r\n\r\nQuisque sollicitudin ipsum id justo fringilla, a tincidunt erat sodales. Donec tristique malesuada porttitor. Maecenas aliquam nulla vel elit condimentum, sed tempus arcu porttitor. Donec vel velit nisi. Nullam non tempus augue. Mauris augue purus, sodales et risus eu, volutpat auctor erat. Nullam commodo vitae velit vel iaculis. Donec egestas est ac massa ultrices convallis. Praesent sed sodales enim.\r\n\r\nPellentesque egestas fringilla mi, at mattis quam laoreet sed. Duis egestas auctor lectus, sed bibendum mauris vehicula sit amet. Donec a dolor nunc. Donec in tincidunt turpis. Suspendisse potenti. Phasellus ut neque nec tortor dignissim suscipit eu et purus. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Cras condimentum lectus eget lacus semper, vel aliquet magna maximus. Aenean efficitur euismod felis eget tempor. Quisque sagittis dui orci, nec molestie ante aliquam et. Etiam ut sem sagittis, congue metus sed, efficitur nisl. Sed viverra pulvinar ex quis volutpat. Praesent rutrum sem risus, sed tempus urna luctus eget.\r\n\r\nMauris non urna eleifend, fermentum nunc et, pellentesque urna. Aenean vehicula, urna non pellentesque aliquet, est massa ornare odio, id tincidunt enim metus id libero. Nullam dictum elementum sapien, condimentum tincidunt odio sodales non. Etiam porttitor condimentum lobortis. Ut varius interdum bibendum. Quisque commodo iaculis sagittis. Cras in lorem nec eros placerat commodo eget vel eros. Proin at nibh ex. Etiam sit amet erat metus. Quisque fermentum turpis non tortor congue, a bibendum ligula congue. Duis ante risus, hendrerit pharetra tortor eu, cursus venenatis odio.",
                CreatedAt = new DateTime(2023, 07,12),
            },
        };

        [HttpGet]
        public List<Blog> GetBlogs()
        {
            var blogList = BlogList.OrderBy(x => x.CreatedAt).ToList();
            return blogList;
        }

        [HttpGet("/list")]
        public List<Blog> GetBlogsOrder([FromQuery] string name = "abc")
        {
            var blogList = BlogList.OrderBy(x => x.Title).ToList();
            if (name != "abc")
            {
                blogList = BlogList.OrderByDescending(x => x.Title).ToList();
                
            }

            return blogList;
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] Blog newBlog)
        {
            var blog = BlogList.SingleOrDefault(x => x.Id == newBlog.Id);
            if (blog is not null)
            {
                return BadRequest();
            }
            else
                BlogList.Add(newBlog);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateBlog(int id, [FromBody] Blog updatedBlog)
        {
            var blog = BlogList.SingleOrDefault(x => x.Id == id);
            if (blog is null)
            {
                return BadRequest();
            }
            else
            {
                blog.Title = updatedBlog.Title != default ? updatedBlog.Title : blog.Title;
                blog.Content = updatedBlog.Content != default ? updatedBlog.Content : blog.Content;
                blog.CreatedAt = updatedBlog.CreatedAt != default ? updatedBlog.CreatedAt : blog.CreatedAt;
                return Ok();

            }
        }

        [HttpPatch]
        public IActionResult UpdateBlogTitle(int id, [FromBody] string updatedTitle)
        {
            var blog = BlogList.SingleOrDefault(x => x.Id == id);
            if (blog is null)
            {
                return BadRequest();
            }
            else
            {
                blog.Title = updatedTitle != default ? updatedTitle : blog.Title;
                return Ok();

            }
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            var blog = BlogList.SingleOrDefault(x => x.Id == id);
            if (blog is null)
            {
                return BadRequest();
            }
            else
            {
                BlogList.Remove(blog);
            }
            return Ok();
        }
    };



}