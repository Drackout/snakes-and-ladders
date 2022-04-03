# Snakes and Ladders

Jogo de tabuleiro de corrida com dados implementado numa aplicação de consola .NET.

## Autoria

### João Inácio (a22102115)

- Implementação de funções para movimento do jogador
- Explicação da estrutura do programa
- Geração do tabuleiro

### Micael Teixeira (a22103816)

- Fluxogramas do programa
- Implementação do *game loop*
- UI

### Repositório

O repositório remoto utilizado encontra-se em https://github.com/Drackout/snakes-and-ladders.

## Arquitetura da solução

O código comecou por ser organizado com a criação do tabuleiro, seguido do seu preenchimento e da sua demonstração inicial para o jogador.
Após a criação do tabuleiro, seguiu-se a criação das funções que permitem ao jogador rolar os dados e de andarem para a frente e para trás no tabuleiro.

Para construir a lógica para movimento do jogador, foram criados métodos para
converter células da matriz do tabuleiro para posições numeradas e vice-versa.
Desta forma, consegue-se mais facilmente realizar o movimento linear:
converte-se a posição do jogador para um número, soma-se a distância a
percorrer (pode ser negativa) e converte-se de volta para formato linha e coluna
para atualizar a posição do jogador.

Para gerar números aleatórios, foi usada a classe [`Random`](https://docs.microsoft.com/en-us/dotnet/api/system.random?view=netcore-3.1)
da API da .NET.
A Microsoft [recomenda evitar o uso de múltiplas instâncias da classe](https://docs.microsoft.com/en-us/dotnet/api/system.random?view=netcore-3.1#avoiding-multiple-instantiations), pelo que foi declarada uma varíavel
estática para guardar a instância única que é utilizada no programa.

### Dados

- O tabuleiro é representado por uma matriz de `SpaceType`.
- `SpaceType` é um enumerado que representa o tipo que uma determinada casa tem.
- Um jogador é representado por um array de comprimento 2.
  Os dois elementos representam a linha e a coluna em que o jogador está,
  por essa ordem.

### Fluxograma da sequencia lógica do programa

![program flowchart](LP1.png "program flowchart")

### Função **Verify_Tile()**

![program Verify_Tile function](LP1_Function.png "program Verify_Tile function")

## Referências

- Documentação .NET (https://docs.microsoft.com/en-us/dotnet/?view=netcore-3.1)
