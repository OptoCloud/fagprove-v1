# Planning

This document describes the planning phase for the first sprint of this project.

During this initial planning phase I created the [developer documentation](documentation_developer.md) document with the [infrastructure](infrastructure.md) document.

## Goals

The goal of this project is to make a website for keeping track of projects and their tasks.

Users should be able to create projects with titles and descriptions, and add tasks to these projects with titles, descriptions, due dates, and statuses.

## Process

The process used for this project is the [Agile](https://en.wikipedia.org/wiki/Agile_software_development) methodology.

This means that the project is divided into sprints, and each sprint is divided into tasks.

Code pushed to the `master` branch of github will automatically trigger a build, test, and deploy pipeline.

The pipeline will deploy the code to Cloudflare and Azure on success.

This provides Continuous Integration (`CI`) and Continuous Deployment (`CD`) for the project. (`CI/CD`).

The result of this is instant feedback and fast iteration on the source code leading to a more efficient development process.

## Roadmap

The roadmap for this project is as follows:

- [x] Create initial planning, infratructure, and technology documentation.
- [ ] Configure infrastructure (Mentioned in [infrastructure](infrastructure.md)).
- [ ] Configure database with models.
- [ ] Create a backend API with swagger specification.
- [ ] Create a frontend with Svelte.
- [ ] Create a Continuous Integration, Continuous Deployment (`CI/CD`) pipeline with GitHub Actions.
- [ ] Test the soltuion and fix any bugs.
- [ ] Create a user manual.
- [ ] Create a presentation.
- [ ] Present the project.
- [ ] Review and reflect on project decisions.

## Time management

`[Dev]` means that the task is development related.

`[Doc]` means that the task is documentation related.

|                   | Thursday         | Friday               | Monday          | Tuesday          | Wedensday                        | Thursday         | Friday                |
| :---------------- | ---------------- | -------------------- | --------------- | ---------------- | -------------------------------- | ---------------- | --------------------- |
| **09:00 - 11:00** | Planning         | Infrastructure setup | `[Dev]` Backend | `[Dev]` Backend  | `[Dev]` Frontend                 | `[Doc]` Solution | Presentation & review |
| **11:00 - 13:00** | Planning         | Infrastructure setup | `[Dev]` Backend | `[Dev]` Backend  | `[Dev]` Frontend                 | `[Doc]` Solution | Presentation & review |
| **13:00 - 15:00** | `[Doc]` Solution | Infrastructure setup | `[Dev]` Backend | `[Dev]` Frontend | `[Dev]` Backend, Frontend, CI/CD | `[Doc]` Solution | Presentation & review |
| **15:00 - 17:00** | `[Doc]` Solution | Infrastructure setup | `[Dev]` Backend | `[Dev]` Frontend | `[Dev]` Backend, Frontend, CI/CD | `[Doc]` Solution | Presentation & review |

## Resources

The resources used for this project are mentioned in the [infrastrucutre](infrastructure.md) document.

## Cost

The cost of this project will be very low.

According to Azures [pricing calculator](https://azure.microsoft.com/nb-no/pricing/calculator/) we can estimate these costs:

- Azure App Service: **610,69 NOK / month**
- Azure SQL Database: **78,10 NOK / month**

## Sources

On day 1 I had a meeting with colleagues to discuss the project, and Infrastructure/Technology choices.

I also got input on the documentation and its structure from other colleagues.

Sources are linked in-line in the documentation.
