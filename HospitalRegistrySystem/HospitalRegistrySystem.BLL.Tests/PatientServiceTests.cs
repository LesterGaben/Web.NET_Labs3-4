using Moq;
using AutoMapper;
using HospitalRegistrySystem.BLL.Services;
using HospitalRegistrySystem.DAL.Repositories.Inerfaces;
using HospitalRegistrySystem.DAL.Entities;
using HospitalRegistrySystem.Common.DTOs.Patient;

namespace HospitalRegistrySystem.BLL.Tests {
    public class PatientServiceTests {
        private readonly Mock<IGenericRepository<Patient>> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly PatientService _patientService;

        public PatientServiceTests() {
            _mockRepository = new Mock<IGenericRepository<Patient>>();
            _mockMapper = new Mock<IMapper>();
            _patientService = new PatientService(_mockRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsAllPatients() {
            // Arrange
            var patients = new List<Patient> {
            new Patient { Id = 1, FullName = "John Doe", DateOfBirth = new DateOnly(1990, 1, 1), Address = "123 Main St", PhoneNumber = "1234567890" },
            new Patient { Id = 2, FullName = "Jane Smith", DateOfBirth = new DateOnly(1992, 2, 2), Address = "456 Elm St", PhoneNumber = "0987654321" }
        };
            var patientDtos = new List<PatientDTO> {
            new PatientDTO { PatientId = 1, FullName = "John Doe", DateOfBirth = new DateOnly(1990, 1, 1), Address = "123 Main St", PhoneNumber = "1234567890" },
            new PatientDTO { PatientId = 2, FullName = "Jane Smith", DateOfBirth = new DateOnly(1992, 2, 2), Address = "456 Elm St", PhoneNumber = "0987654321" }
        };
            _mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(patients);
            _mockMapper.Setup(mapper => mapper.Map<IEnumerable<PatientDTO>>(patients)).Returns(patientDtos);

            // Act
            var result = await _patientService.GetAllAsync();

            // Assert
            Assert.Equal(patientDtos, result);
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsPatient_WhenPatientExists() {
            // Arrange
            var patient = new Patient { Id = 1, FullName = "John Doe", DateOfBirth = new DateOnly(1990, 1, 1), Address = "123 Main St", PhoneNumber = "1234567890" };
            var patientDto = new PatientDTO { PatientId = 1, FullName = "John Doe", DateOfBirth = new DateOnly(1990, 1, 1), Address = "123 Main St", PhoneNumber = "1234567890" };
            _mockRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(patient);
            _mockMapper.Setup(mapper => mapper.Map<PatientDTO>(patient)).Returns(patientDto);

            // Act
            var result = await _patientService.GetByIdAsync(1);

            // Assert
            Assert.Equal(patientDto, result);
        }

        [Fact]
        public async Task CreateAsync_ReturnsNewPatientId() {
            // Arrange
            var patientDto = new CreateUpdatePatientDTO { FullName = "Jane Smith", DateOfBirth = new DateOnly(1992, 2, 2), Address = "456 Elm St", PhoneNumber = "0987654321" };
            var patient = new Patient();
            _mockMapper.Setup(mapper => mapper.Map<Patient>(patientDto)).Returns(patient);
            _mockRepository.Setup(repo => repo.AddAsync(patient)).Callback<Patient>(p => p.Id = 3); // Для прикладу припустимо, що новий ID = 3

            // Act
            var result = await _patientService.CreateAsync(patientDto);

            // Assert
            Assert.Equal(3, result);
        }

        [Fact]
        public async Task UpdateAsync_UpdatesPatient() {
            // Arrange
            var updatePatientDto = new CreateUpdatePatientDTO { FullName = "Jane Smith Updated", DateOfBirth = new DateOnly(1992, 2, 2), Address = "456 Updated St", PhoneNumber = "0987654321" };
            var patient = new Patient { Id = 2, FullName = "Jane Smith", DateOfBirth = new DateOnly(1992, 2, 2), Address = "456 Elm St", PhoneNumber = "0987654321" };
            var updatedPatientDto = new PatientDTO { PatientId = 2, FullName = "Jane Smith Updated", DateOfBirth = new DateOnly(1992, 2, 2), Address = "456 Updated St", PhoneNumber = "0987654321" };
            _mockRepository.Setup(repo => repo.GetByIdAsync(2)).ReturnsAsync(patient);
            _mockMapper.Setup(mapper => mapper.Map(updatePatientDto, patient)).Returns(patient);
            _mockMapper.Setup(mapper => mapper.Map<PatientDTO>(patient)).Returns(updatedPatientDto);

            // Act
            var result = await _patientService.UpdateAsync(2, updatePatientDto);

            // Assert
            Assert.Equal(updatedPatientDto, result);
        }

        [Fact]
        public async Task DeleteAsync_DeletesPatient() {
            // Arrange
            var patient = new Patient { Id = 1, FullName = "John Doe" };
            _mockRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(patient);

            // Act
            await _patientService.DeleteAsync(1);

            // Assert
            _mockRepository.Verify(repo => repo.DeleteAsync(patient), Times.Once());
        }


    }
}