using System.Collections.Generic;

namespace GitHubProjectCore.Model
{
    public class UserResponse
    {
        public string nextPage { get; set; }

        public List<UserListResponse> userList { get; set; }

    }

    public class UserListResponse
    {
        public string Login { get; set; }
        public string Url { get; set; }
    }
}
