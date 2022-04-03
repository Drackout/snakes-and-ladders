# Estrutura do programa

Este documento descreve a estrutura pensada para a implementação do jogo.

## Dados

- O tabuleiro é representado por uma matriz de `SpaceType`.
- `SpaceType` é um enumerado que representa o tipo que uma determinada casa tem.
- Um jogador é representado por um array de comprimento 2.
  Os dois elementos representam a linha e a coluna em que o jogador está,
  por essa ordem.

## Métodos

- gerar tabuleiro
- desenhar tabuleiro (se calhar numa secção à parte)
- mover jogador

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
