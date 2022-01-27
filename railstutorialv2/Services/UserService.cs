//using System;
//using railstutorialv2.Models;
//using railstutorialv2.Repository;

//namespace railstutorialv2.Services
//{
//	public class UserService: IUserService
//	{
//        public User Create(User user)
//        {
//            user.Id = UserRepository.Users.Count + 1;
//            UserRepository.Users.Add(user);
//            return user;
//        }

//        public bool Delete(int id)
//        {
//            var oldUser = UserRepository.Users.FirstOrDefault(o => o.Id == id);
//            if (oldUser is null) return false;
//            UserRepository.Users.Remove(oldUser);
//            return true;
//        }

//        public User? Get(int id)
//        {
//            var user = UserRepository.Users.FirstOrDefault(o => o.Id == id);
//            return user;
//        }

//        public List<User>? List()
//        {
//            var users = UserRepository.Users;
//            return users;
//        }

//        public User? Update(User newUser)
//        {
//            var oldUser = UserRepository.Users.FirstOrDefault(o => o.Id == newUser.Id);

//            if (oldUser is null) return null;

//            oldUser.Name = newUser.Name;
//            oldUser.Email = newUser.Email;

//            return newUser;
//        }
//    }
//}

