# GitHubProject by Williann Freitas

## _An API made whit Asp Net Core 3.1 whit Github library Ocktokit_
Swagger for tests: http://williannfreitas-001-site1.ctempurl.com/index.html

Github library Ocktokit documentation: http://octokitnet.readthedocs.io/en/latest/.

My focus on this project is the Backend of the application, then i builded
the API whit the three endpoint GET and for a better user experience i implemented swagger as a index of the site.   

```sh
#First EndPoint: http://williannfreitas-001-site1.ctempurl.com/api/Users?since={number}
I made a list of 100 users separete in 10 pages whit filtered information about each user.
For consult the information of the page, just need to enter in the swagger input a number between 1 and 10.
```

```sh
#Second EndPoint:http://williannfreitas-001-site1.ctempurl.com/api/users/{:username}/details
To consult the information of one user, just type the logon name in swagger input.
```

```sh
#Third EndPoint:http://williannfreitas-001-site1.ctempurl.com/api/users/{:username}/repos
Same process to consult the list of repositorys. Type the user name in swagger input, and it will return filtred information about all repositorys.
```
