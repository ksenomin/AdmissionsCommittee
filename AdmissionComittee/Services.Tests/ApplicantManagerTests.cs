using AdmissionComittee.Entities;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Repository.Contracts;
using Services.Contracts;
using Xunit;

namespace Services.Tests
{
    /// <summary>
    /// Тесты для <see cref="ApplicantManager"/>
    /// </summary>
    public class ApplicantManagerTests
    {
        private readonly ApplicantManager applicantManager;
        private readonly Mock<IApplicantStorage> storageMock = new();

        /// <summary>
        /// Инициализация
        /// </summary>
        public ApplicantManagerTests()
        {
            var loggerFactory = new Mock<ILoggerFactory>();
            loggerFactory.Setup(x => x.CreateLogger(It.IsAny<string>())).Returns(Mock.Of<ILogger>());
            applicantManager = new(storageMock.Object, loggerFactory.Object);
        }

        /// <summary>
        /// <see cref="ApplicantManager.Add(Applicant, CancellationToken)"/> должен работать
        /// </summary>
        [Fact]
        public async Task AddShouldWork()
        {
            // Arrange
            var applicant = new Applicant();

            // Act
            await applicantManager.Add(applicant, CancellationToken.None);

            // Assert
            storageMock.Verify(mock => mock.Add(applicant, CancellationToken.None), Times.Once());
            storageMock.VerifyNoOtherCalls();
        }

        /// <summary>
        /// <see cref="ApplicantManager.Delete(Guid, CancellationToken)"/> должен работать
        /// </summary>
        [Fact]
        public async Task RemoveShouldWork()
        {
            // Arrange
            var applicant = new Applicant();

            // Act
            await applicantManager.Delete(applicant.Id, CancellationToken.None);

            // Assert
            storageMock.Verify(mock => mock.Delete(applicant.Id, CancellationToken.None), Times.Once());
            storageMock.VerifyNoOtherCalls();
        }

        /// <summary>
        /// <see cref="ApplicantManager.GetAll(CancellationToken)"/>
        /// должен вернуть пустой список
        /// </summary>
        [Fact]
        public async Task GetAllShouldReturnEmpty()
        {
            // Arrange
            storageMock.Setup(mock => mock.GetAll(CancellationToken.None))
                .ReturnsAsync([]);

            // Act
            var actual = await applicantManager.GetAll(CancellationToken.None);

            // Assert
            actual.Should().BeEmpty();
        }

        /// <summary>
        /// <see cref="ApplicantManager.GetAll(CancellationToken)"/>
        /// должен вернуть список со значением.
        /// </summary>
        [Fact]
        public async Task GetAllShouldReturnValue()
        {
            // Arrange
            ICollection<Applicant> expected = new List<Applicant>()
            {
                new ()
            };
            storageMock.Setup(mock => mock.GetAll(CancellationToken.None))
            .ReturnsAsync(expected);

            // Act
            var actual = await applicantManager.GetAll(CancellationToken.None);

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }

        /// <summary>
        /// <see cref="ApplicantManager.Update(Applicant, CancellationToken)"/> должен работать
        /// </summary>
        [Fact]
        public async Task UpdateShouldWork()
        {
            // Arrange
            var applicant = new Applicant();

            // Act
            await applicantManager.Update(applicant, CancellationToken.None);

            // Assert
            storageMock.Verify(mock => mock.Update(applicant, CancellationToken.None), Times.Once());
            storageMock.VerifyNoOtherCalls();
        }

        /// <summary>
        /// <see cref="ApplicantManager.GetStatistics(CancellationToken)"/> должен работать
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetStatisticsShouldWork()
        {
            // Arrange
            var expected = new ApplicantStatistics
            {
                ApplicantsCount = 2,
                ApplicantsCountPassed = 1,
            };

            storageMock
                .Setup(x => x.GetStatistics(It.IsAny<CancellationToken>()))
                .ReturnsAsync(expected);

            // Act
            var actual = await applicantManager.GetStatistics(CancellationToken.None);

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }

        /// <summary>
        ///<see cref="ApplicantManager.GetById(Guid, CancellationToken)"/> должен работать
        /// </summary>
        [Fact]
        public async Task GetByIdShouldWork()
        {
            // Arrange
            var aplicant = new Applicant();

            // Act
            await applicantManager.GetById(aplicant.Id, CancellationToken.None);

            // Assert
            storageMock.Verify(mock => mock.GetById(aplicant.Id, CancellationToken.None), Times.Once());
            storageMock.VerifyNoOtherCalls();
        }
    }
}
