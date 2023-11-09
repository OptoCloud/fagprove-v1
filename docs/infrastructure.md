# Infrastructure

This document describes the infrastructure used for this project.

You can find schematics of the infrastructure in the [diagrams](diagrams) folder.

Click on any of the headers below to learn more about the mentioned topic.

## Table of Contents

- **Cloudflare**

  - [**DNS**](#cloudflare-dns) - Domain name hosting
  - [**Pages**](#cloudflare-pages) - Static website hosting

- **Azure**

  - [**App Service**](#azure-app-service) - Web application hosting
  - [**SQL Database**](#azure-sql-database) - Database hosting
  - [**Key Vault**](#azure-key-vault) - Secret storage

- **Auth0**

  - [**Authentication**](#auth0-authentication) - User authentication

- **GitHub**
  - [**Actions**](#github-actions) - CI/CD pipeline

<br><br>

<img src="static/Cloudflare_Logo.png" height="100" alt="Cloudflare Logo" />

## [What is Cloudflare?](https://www.cloudflare.com/what-is-cloudflare/)

Cloudflare is a global service provider that helps websites load faster, stay protected from attacks, and so much more.

They do this by acting as a middleman between the user and the website, or by hosting the website directly.

They are known for their DDoS protection, their global CDN (Content Delivery Network), and their easy-to-use DNS management.

All of this is provided for free, with the option to pay for additional features or higher usage limits.

## [Cloudflare DNS](https://www.cloudflare.com/application-services/products/dns/)

Cloudflare DNS allows you to manage your domain nameservers, DNS records, proxy settings, and more.

It was selected for the following reasons:

- I have a lot of experience with it
- It has managed domains, SSL certificates, DNS records, and more for free
- It has request procying, caching, and DDoS protection all included for free as well

Currently, we use Cloudflare DNS to manage the following domains:

- `optocloud.no`

## [Cloudflare Pages](https://www.cloudflare.com/developer-platform/pages/)

Cloudflare Pages allows you to host web-apps on Cloudflare's global network of servers.

It was selected for the following reasons:

- It supports hosting Svelte SPA's
- I have a lot of experience with it
- It's free for low-traffic websites with the option to pay for higher usage limits
- Automated deployments from GitHub repositories are easy to set up
- It's fast by default due to edge caching, and it being serverless increases its reliability and scalability

<br><br>

<img src="static/Azure_Logo.png" height="100" alt="Azure Logo" />

## [What is Azure?](https://azure.microsoft.com/en-us/resources/cloud-computing-dictionary/what-is-azure/)

Azure is a cloud computing service created and managed by Microsoft.

They provide a wide range of services that can be used to build virtually any type of application or product.

## [Azure App Service](https://azure.microsoft.com/en-us/products/app-service/)

Azure App Service is a service that allows you to host web applications and APIs.

It was selected for the following reasons:

- It supports hosting ASP.NET API's with ease
- Scalability is easy to set up and manage
- Secrets can be stored in Azure Key Vault and accessed easily
- It supports continuous deployment from GitHub repositories
- Azure is a trusted provider with a lot of experience in the industry and has good documentation

## [Azure SQL Database](https://azure.microsoft.com/en-us/products/azure-sql/database/)

Azure SQL Database is a service that allows you to host SQL databases.

It was selected for the following reasons:

- It's a relational database, which is easy to understand and something I have experience with
- It's a managed service, meaning that Microsoft handles all of the maintenance, updates, security, scaling, etc.
- It's on the same platform as the backend meaning that they can easily communicate with each other in a secure way via private virtual networks
- Azure is a trusted provider with a lot of experience in the industry and has good documentation

## [Azure Key Vault](https://azure.microsoft.com/en-us/products/key-vault/)

Azure Key Vault is a service that allows you to store and manage secrets.

It was selected for the following reasons:

- Easy to set up and manage
- It's integrated with Azure App Service, meaning that secrets can be accessed easily from the backend

<br><br>

<img src="static/Auth0_Logo.svg" height="100" alt="Auth0 Logo" />

## [What is Auth0?](https://auth0.com/)

Auth0 is a service that allows you to add authentication to your applications.

It was selected for the following reasons:

- Setting up my own authentication will take more time to set up and will be less secure
- It's a fully managed authentication provider with a lot of experience in the industry
- Good documentation for a wide range of frameworks and languages
- Auth0 has a free tier for up to 7500 active users

<br><br>

<img src="static/Github_Logo.png" height="100" alt="GitHub Logo" />

## [What is GitHub?](https://github.com/)

GitHub is a git provider that allows you to host, collaborate on, and deploy code with other developers around the world.

## [GitHub Actions](https://docs.github.com/en/actions/learn-github-actions/understanding-github-actions)

GitHub Actions is a CI/CD pipeline that allows you to automate your build, test, and deployment processes.

It was selected for the following reasons:

- Easy to set up and manage
- I have a lot of experience with it
- Used extensively in the industry, therefore has good documentation and community support
