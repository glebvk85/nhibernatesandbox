using NHibernate;
using NHibernateSandbox.Model;
using NHibernateSandbox.Utils;
using NUnit.Framework;

namespace NHibernateSandbox.Tests
{
    [TestFixture]
    public class LazyLoadFixture : TestBase
    {
        [Test]
        public void CanLazyLoadPhoto()
        {
            //Arrange
            var p = new Person() { Name = "BatMan", Photo = new byte[]{0, 1, 2, 3, 4, 5}};
            Session.Save(p);
            Session.Clear();

            //Act
            var actual = Session.Get<Person>(p.Id);

            //Assert
            Assert.That(actual.Name, Is.EqualTo(p.Name));
            Assert.That(actual.Photo, Is.EqualTo(p.Photo));
        }

        [Test]
        public void LazyLoadPhoto()
        {
            //Arrange
            var p = new Person() { Name = "BatMan", Photo = new byte[] { 0, 1, 2, 3, 4, 5 } };
            Session.Save(p);
            Session.Clear();

            //Act
            var actual = Session.Get<Person>(p.Id);

            //Assert
            Assert.That(NHibernateUtil.IsPropertyInitialized(actual, "Photo"), Is.False);
        }
    }
}