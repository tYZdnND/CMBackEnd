using ContactManagement.Controllers;
using ContactManagement.Models;
using ContactManagement.Services.ContactService;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;

namespace ContactManagement.Test
{
    public class ContactControllerTests
    {
        [Fact]
        public async void GetAll_Returns_Correct_Number_Of_Contacts()
        {
            //Arrange
            IContactService provider = A.Fake<IContactService>();
            var controller = new ContactController(provider);

            var fakeContacts = new List<Contact>();
            var c1 = new Contact()
            {
                Id = 1,
                FirstName = "",
                LastName = "",
                PhoneNumber = ""
            };

            var c2 = new Contact()
            {
                Id = 2,
                FirstName = "",
                LastName = "",
                PhoneNumber = ""
            };

            var c3 = new Contact()
            {
                Id = 3,
                FirstName = "",
                LastName = "",
                PhoneNumber = ""
            };
            fakeContacts.Add(c1);
            fakeContacts.Add(c2);
            fakeContacts.Add(c3);
            var dummyContacts = A.CollectionOfDummy<Contact>(fakeContacts.Count()).AsEnumerable();

            A.CallTo(() => provider.GetAll()).Returns(Task.FromResult(fakeContacts));

            //Act
            var actionResult = await controller.GetAll();

            //Assert
            var result = actionResult.Result as OkObjectResult;
            Assert.NotNull(result);
            Assert.NotNull(result.Value);
            var returnContacts = result.Value as List<Contact>;          
            Assert.Equal(fakeContacts.Count(), returnContacts.Count);
        }

        [Fact]
        public async void GetSingle_Returns_Correct_Contact()
        {
            //Arrange
            IContactService provider = A.Fake<IContactService>();
            var controller = new ContactController(provider);

            var c1 = new Contact()
            {
                Id = 1,
                FirstName = "",
                LastName = "",
                PhoneNumber = ""
            };

            A.CallTo(() => provider.GetSingle(c1.Id)).Returns(Task.FromResult<Contact?>(c1));

            //Act
            var actionResult = await controller.GetSingle(c1.Id);

            //Assert
            var result = actionResult.Result as OkObjectResult;
            Assert.NotNull(result);
            Assert.NotNull(result.Value);
            var returnContact = result.Value as Contact;
            Assert.Equal(c1.Id, returnContact.Id);
        }
    }
}