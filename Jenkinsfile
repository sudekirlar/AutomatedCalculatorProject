pipeline {
    agent any

    options {
        cleanWs()
    }

    triggers {
        pollSCM('H/1 * * * *')
    }

    environment {
        PATH = "${tool 'dotnetsdk-8.0'}:${env.PATH}"
    }


    stages {
        stage('Build') {
            steps {
                sh 'dotnet build'
            }
        }

        stage('Test') {
            steps {
                sh 'dotnet test'
            }
        }
    }
}