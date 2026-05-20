using ServerApp.Database.Repositories;
using ServerApp.Models;

namespace ServerApp.Database
{
    public class SeedData
    {
        public void InsertSampleData()
        {
            UserRepository userRepository =
                new UserRepository();

            MachineRepository machineRepository =
                new MachineRepository();

            SessionRepository sessionRepository =
                new SessionRepository();

            if (!userRepository.UserExists("admin"))
            {
                userRepository.AddUser(new User
                {
                    Username = "admin",
                    Password = "123",
                    Role = "Admin"
                });
            }

            if (!userRepository.UserExists("client01"))
            {
                userRepository.AddUser(new User
                {
                    Username = "client01",
                    Password = "123",
                    Role = "Client"
                });
            }

            if (!userRepository.UserExists("client02"))
            {
                userRepository.AddUser(new User
                {
                    Username = "client02",
                    Password = "123",
                    Role = "Client"
                });
            }

            machineRepository.AddMachine(new Machine
            {
                MachineName = "PC-01",
                IpAddress = "192.168.1.10",
                Status = "Online"
            });

            machineRepository.AddMachine(new Machine
            {
                MachineName = "PC-02",
                IpAddress = "192.168.1.11",
                Status = "Offline"
            });

            machineRepository.AddMachine(new Machine
            {
                MachineName = "PC-03",
                IpAddress = "192.168.1.12",
                Status = "Playing"
            });

            sessionRepository.StartSession(new Session
            {
                UserId = 1,
                MachineId = 1,
                StartTime = DateTime.Now.ToString()
            });

            sessionRepository.StartSession(new Session
            {
                UserId = 2,
                MachineId = 3,
                StartTime = DateTime.Now.ToString()
            });
        }
    }
}