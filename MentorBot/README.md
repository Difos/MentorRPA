# Mentor RPA 

** Esse software foi desenvolvido para suprir a demanda de extrair mais de 21 mil laudos do 
sistema mentor, sistema que tem como função o processo de ultrasom de eixos metalicos.

** a gravação do ultrasom gera um arquivo .MDP, porém para analisar os dados utiliando algum modelo de machine learning
é necessario que se converta esse arquivo em 2 arquivos de CSV, 1 para os dados de amplitude e 1 arquivo para profundidade


# Funcionamento

** Ao iniciar esse programa o sistema abre o mentor caso ele não esteja rodando, busca o arquivo no pen drive ou hd, e inicia a extração dos arquivos
de amplitude AMP e profundidade TOF. Ex: se tivermos 300 arquivos MPD no pendrive o prgrama criara 600 arquivos de CSV.

** Existe um padrão para o nome dos arquivos, pois devem obdescer a ordem de "nome do arquivo.mpd_nome_arquivo_extraido_csCan1_AMP.csv"
