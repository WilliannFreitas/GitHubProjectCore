using GitHubProjectCore.Model;
using Microsoft.AspNetCore.Mvc;
using Octokit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GitHubProjectCore.Controllers
{
    public class UsersController : Controller
    {
        #region Primeiro Endpoint

        /// <summary>
        /// This endpoint must return a list of GitHub users and the link for the next page.
        /// </summary>
        /// <param name="since"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/[Controller]")]
        public async Task<UserResponse> Create(int since)
        {
            //Pegando dados do Aplicativo Criado no GitHub para uso
            GitHubClient client = await Authentication();

            //Realizando a Montagem do Objeto/Passagem de parametros a serem pesquisados

            var request = new SearchUsersRequest("a")
            {
                Page = since
            };

            //Retorno de Pesquisa de Usuários
            var response = await client.Search.SearchUsers(request);

            //Tratando dados | Lista de usuário
            var usersResults = new List<UserListResponse>();

            foreach (var item in response.Items)
            {
                //Atribuindo valores da pesquisa ao objeto
                var users = new UserListResponse()
                {
                    Login = item.Login,
                    Url = item.Url,
                };
                usersResults.Add(users);
            }

            //Atribiundo Link a objeto de retorno.
            var userResponse = new UserResponse();
            userResponse.nextPage = $"linkfake.com/api/users?since={since + 1}";
            userResponse.userList = usersResults;

            return userResponse;
        }
        #endregion

        #region Segundo Endpoint


        /// <summary>
        /// This endpoint must return the details of a GitHub user
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/[Controller]/{nome}/details")]
        public async Task<IReadOnlyList<User>> Details(string nome)
        {
            //Pegando dados do Aplicativo Criado no GitHub para uso
            GitHubClient client = await Authentication();

            //Realizando a Montagem do Objeto/Passagem de parametros a serem pesquisados
            var request = new SearchUsersRequest(nome);

            //Retorno de Pesquisa de Usuarios
            var response = await client.Search.SearchUsers(request);

            return response.Items;
        }
        #endregion

        #region Terceiro Endpoint
        /// <summary>
        /// This endpoint must return a list with all user repositories
        /// </summary>
        /// <param name="nome"></param>
        /// <returns>List<RepositoryResponse></returns>
        [HttpGet]
        [Route("api/[Controller]/{nome}/repos")]
        public async Task<List<RepositoryResponse>> Repos(string nome)
        {
            //Pegando dados do Aplicativo Criado no GitHub para uso
            GitHubClient client = await Authentication();

            //Realizando a Montagem do Objeto/Passagem de parametros a serem pesquisados
            var request = new SearchRepositoriesRequest()
            {
                User = nome
            };

            //Retorno de pesquisa de repositórios
            var response = await client.Search.SearchRepo(request);

            //Tratando dados
            //Lista com os repositórios do usuário
            var repositoryResults = new List<RepositoryResponse>();


            foreach (var item in response.Items)
            {
                //Atribuido valores da pesquisa ao objeto
                var repository = new RepositoryResponse()
                {
                    Name = item.Name,
                    FullName = item.FullName,
                    Language = item.Language,
                    Url = item.Url
                };

                repositoryResults.Add(repository);
            }

            return repositoryResults;
        }

        #endregion

        #region Autenticação do Usuário
        /// <summary>
        /// Pegando dados do Aplicativo Criado no GitHub e Gera um Client
        /// </summary>
        /// <returns>GitHubClient</returns>
        private async Task<GitHubClient> Authentication()
        {
            GitHubClient client = new GitHubClient(new ProductHeaderValue("WillianProjectAAAA"));

            return client;
        }

        #endregion

    }
}
