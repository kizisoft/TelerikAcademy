namespace Cars.Tests.Mocks
{
    using Cars.Contracts;
    using Cars.Models;
    using Moq;
    using System.Linq;

    public class MoqCarsRepository : CarRepositoryMock, ICarsRepositoryMock
    {
        protected override void ArrangeCarsRepositoryMock()
        {
            var mockedCarsRepository = new Mock<ICarsRepository>();
            mockedCarsRepository.Setup(r => r.Add(It.IsAny<Car>())).Verifiable();
            mockedCarsRepository.Setup(r => r.All()).Returns(this.FakeCarCollection);
            // mockedCarsRepository.Setup(r => r.Search(It.IsAny<string>())).Returns(this.FakeCarCollection.Where(c => c.Make == "BMW").ToList());
            mockedCarsRepository.Setup(r => r.GetById(It.IsAny<int>())).Returns(this.FakeCarCollection.First());

            // Added for the homework >>
            mockedCarsRepository.Setup(r => r.Search(It.IsAny<string>())).Returns(this.FakeCarCollection.Where(c => c != null && c.Make == "BMW").ToList());
            mockedCarsRepository.Setup(r => r.GetById(It.Is<int>(x => x == -1))).Returns(this.FakeCarCollection.Last());
            mockedCarsRepository.Setup(r => r.Search(It.Is<string>(s => s == string.Empty))).Returns(this.FakeCarCollection);
            mockedCarsRepository.Setup(r => r.SortedByMake()).Returns(this.FakeCarCollection.Where(c => c != null).ToList());
            mockedCarsRepository.Setup(r => r.SortedByYear()).Returns(this.FakeCarCollection.Where(c => c != null).ToList());
            // Added for the homework <<

            this.CarsData = mockedCarsRepository.Object;
        }
    }
}
