CREATE DATABASE gerenciador_tarefas;

USE gerenciador_tarefas;

CREATE TABLE Tarefas (
    id INT AUTO_INCREMENT PRIMARY KEY,
    titulo VARCHAR(100) NOT NULL,
    descricao VARCHAR(255),
    datavencimento DATE NOT NULL,
    concluida BOOLEAN NOT NULL
);
