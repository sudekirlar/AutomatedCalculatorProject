pipeline {
    agent any

    triggers {
        pollSCM('H/1 * * * *')
    }

    tools {
        sdk 'dotnetsdk-6.0'
    }

    stages {
        stage('Build') {
            steps {
                bat 'dotnet build'
            }
        }

        stage('Test') {
            steps {
                bat 'dotnet test'
            }
        }
    }
}