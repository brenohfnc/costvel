DELETE FROM tipo_custos WHERE id > 0;

INSERT INTO tipo_custos (nome, descricao, ordem)
VALUES ('Acomodação', 'O gasto diário com hotéis, pousadas, AirBnBs, etc.', 1);

INSERT INTO tipo_custos (nome, descricao, ordem)
VALUES ('Almoço', 'O gasto diário com almoço. Considere o custo para 1 pessoa.', 2);

INSERT INTO tipo_custos (nome, descricao, ordem)
VALUES ('Janta', 'O gasto diário com janta. Considere o custo para 1 pessoa.', 3);

INSERT INTO tipo_custos (nome, descricao, ordem)
VALUES ('Lanches', 'O gasto diário com lanches. Considere o custo para 1 pessoa.', 4);

INSERT INTO tipo_custos (nome, descricao, ordem)
VALUES ('Transporte', 'O gasto diário com transportes privados e públicos (transfers, táxis, metrô, ônibus, etc.)', 5);

INSERT INTO tipo_custos (nome, descricao, ordem)
VALUES ('Compras e Souvenirs', 'O gasto diário com compras gerais e souvenirs.', 6);