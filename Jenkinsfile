pipeline {
    agent any

    options {
        skipDefaultCheckout(true)
    }

    triggers {
        pollSCM('H/1 * * * *')
    }

    environment {
        PATH = "${tool 'dotnetsdk-8.0'}:${env.PATH}"
    }

    stages {
        stage('Checkout') {
            steps {
                cleanWs()     
                checkout scm
            }
        }

        stage('Build') {
            steps {
                sh 'dotnet build Calculator.sln'
            }
        }

        stage('Test') {
            steps {
                sh 'dotnet test Calculator.sln'
            }
        }
    }
}
