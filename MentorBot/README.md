# Mentor RPA 

** Esse software foi desenvolvido para suprir a demanda de extrair mais de 21 mil laudos do 
sistema mentor, sistema que tem como fun��o gerar inspeções de ultrasom de eixos metalicos. afim de encontrar alguma trinca ou avaria interna no eixo.

** a grava��o do ultrasom gera um arquivo .MDP, por�m para analisar os dados utilizando algum modelo de machine learning
� necessario que se converta esse arquivo em 2 arquivos de CSV, 1 para os dados de amplitude e 1 arquivo para profundidade


# Funcionamento

** Ao iniciar esse programa o sistema abre o mentor caso ele n�o esteja rodando, busca o arquivo no pen drive ou hd, e inicia a extra��o dos arquivos
de amplitude AMP e profundidade TOF. Ex: se tivermos 300 arquivos MPD no pendrive o prgrama criara 600 arquivos de CSV.

** Existe um padr�o para o nome dos arquivos, pois devem obdescer a ordem de "nome do arquivo.mpd_nome_arquivo_extraido_csCan1_AMP.csv"

