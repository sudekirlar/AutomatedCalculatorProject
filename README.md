# Automated Calculator Project

This repository contains a .NET 8 Calculator engine developed using the **Test-Driven Development (TDD)** methodology.
The project was implemented as part of the *CEN315 – Introduction to Test Engineering* course and demonstrates a fully automated Continuous Integration (CI) pipeline using both **Jenkins** and **GitHub Actions**.

---

## Core Engineering Principles

This project is built upon key modern software engineering practices:

1. **Test-Driven Development (TDD):**
   The project strictly follows the "Red–Green–Refactor" cycle. For each new functionality (e.g., `Add`, `Divide`), a failing test was written first, followed by minimal implementation to make it pass, and finally a refactor step to improve quality and maintain test coverage.

2. **Unit Testing:**
   Unit tests were developed using the **NUnit** framework. The test suite includes multiple cases such as positive/negative numbers, decimals, zero handling, and exception testing for invalid operations (e.g., `Assert.Throws<DivideByZeroException>`).

3. **Continuous Integration (CI/CD) Automation:**
   The build and test processes are fully automated. Every push to the `main` branch triggers CI pipelines that build, test, and validate the codebase automatically.

4. **Pipeline as Code:**
   All CI configurations are version-controlled and defined as code (`Jenkinsfile` for Jenkins and `dotnet-ci.yml` for GitHub Actions). This ensures reproducibility, transparency, and maintainability across environments.

---

## Technology Stack

* **Language & Platform:** C# (.NET 8)
* **Test Framework:** NUnit
* **Version Control:** Git, GitHub
* **CI/CD Orchestrators:**

  * Jenkins (custom Docker-based setup)
  * GitHub Actions (cloud-hosted)

---

## CI/CD Automation Overview

### 1. Jenkins Pipeline

The Jenkins pipeline is defined in the `Jenkinsfile` using the declarative syntax.

#### Environment Setup

Building .NET 8 projects on Jenkins required a custom environment.
Since the official `jenkins/jenkins:lts` Docker image does not include the .NET SDK or its dependencies, a **custom Docker image** was built using the repository’s `Dockerfile`.

**Dockerfile Highlights:**

```dockerfile
FROM jenkins/jenkins:lts
USER root
RUN apt-get update && apt-get install -y libicu-dev
```

The `libicu-dev` package was required to resolve globalization-related build errors (`MSB1003`).
This image (`sude-jenkins:lts`) was used as the runtime environment for the pipeline.

#### Jenkinsfile Details

The Jenkinsfile automates build and test execution:

* **Polling:**
  `pollSCM('H/1 * * * *')` – Jenkins polls the repository every minute for new commits.

* **.NET SDK Configuration:**
  The environment variable dynamically locates the installed SDK:
  `PATH = "${tool 'dotnetsdk-8.0'}/bin:${env.PATH}"`

* **Pipeline Stages:**

  1. **Cleanup:** Ensures a clean workspace with `cleanWs()`.
  2. **Build:** Runs `dotnet build Calculator.sln`.
  3. **Test:** Executes `dotnet test Calculator.sln`. The build fails immediately if any test fails.

---

### 2. GitHub Actions Workflow

The GitHub Actions workflow is defined in `.github/workflows/dotnet-ci.yml`.
It provides a cloud-based CI alternative to the Jenkins pipeline.

**Workflow Breakdown:**

* **Trigger:** Runs on each push to the `main` branch.
* **Runner:** Executes on a GitHub-hosted Ubuntu machine.
* **Steps:**

  1. Check out repository code (`actions/checkout@v3`)
  2. Install the .NET 8 SDK (`actions/setup-dotnet@v3`)
  3. Build and test the solution using:

     ```yaml
     run: dotnet build Calculator.sln
     run: dotnet test Calculator.sln --no-build
     ```

---

## Build Status

* **Jenkins:** Local instance
* **GitHub Actions**

---

**Sude Kýrlar**
