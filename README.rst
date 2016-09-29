==================
AssistenteLigacoes
==================

Trabalho da disciplina de **Linguagem de Programação II** do curso de Análise e Desenvolvimento de Sistemas do 
Instituto Federal de Educação, Ciência e Tecnologia de São Paulo - Campus São Carlos. Dissiplina mestrada pelo
Prof. Dr. Carlos José De Almeida Pereira a.k.a. *Carlão*.

Objetivo
--------

A comunicação VOIP está cada vez mais comum na atualidade. Nossa proposta para a matéria de LP2 é desenvolver um 
assistente para uma linha de telefone VOIP que auxiliará o usuário na identificação, gerenciamento e consulta de 
todas as ligações feitas e/ou recebidas. A ideia é simples: sistemas VOIP armazenam todas as informações no banco 
de dados, possibilitando assim o gerenciamento e consulta desses dados por sistemas externos.

Estrutura das classes e métodos
-------------------------------

O assistente possuirá a classe principal “Telefone”, que possuirá os atributos DDD e prefixo. A classe “Telefone” 
possuirá os métodos: recebeLigacao, realizaLigacao, finalizaLigacao e buscaGeral. A classe “Ramal” herdará a classe 
“Telefone” e possuirá os atributos sufixo, data/hora do início do atendimento e data/hora do fim do atendimento. A 
classe “Ramal” possuirá, além dos métodos da classe mãe: autenticaUsuario, desligaUsuario, buscaLigacoes, buscaOrigem 
e buscaDestino.

Lembrando que, por não possuirmos um diagrama de classes, documento de requisitos e muito menos um diagrama de entidade 
relacionamento, as classes, métodos e atributos podem sofrer alterações ao decorrer do desenvolvimento.

Entradas e saídas
-----------------

As entradas do software serão as seguintes:
*******************************************

* Autenticação: tela onde o usuário realizará login em um ramal especifico.

* Painel geral: tela onde o usuário poderá inserir um telefone de destino para ser realizado uma ligação sem a necessidade de digitar no próprio terminal.

As saídas do software serão as seguintes:
*****************************************

* Painel geral: tela onde o usuário visualizará o status do seu ramal (ligado, recebendo ligação ou em ligação), o telefone que está sendo chamado ou que está chamando, cidade e estado de origem/destino, operadora e tempo de ligação.

* Relatório de ligações geral: relatório gerado com todas as ligações realizadas por um telefone, com ramal de origem, telefone de destino, tempo de ligação, operadora, cidade e estado de origem/destino.

* Relatório de ligações de ramal: relatório com todas as ligações realizadas e recebidas por um ramal, com telefone de origem/destino, tempo de ligação, operadora, cidade e estado de origem/destino.

* Relatório de ligações não atendidas: um relatório com todas as ligações não atendidas (tanto as realizadas como as recebidas) por um ramal, com telefone de origem/destino, operadora, cidade e estado de origem/destino e data/hora da ligação.
