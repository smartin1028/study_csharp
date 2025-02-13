using System;

namespace WebApplication5.Models
{
    // 게시판 게시판
    // 게시판 게시판
    public class Board
    {
        // 게시글 번호 게시글 번호
        public int? BOARD_ID { get; set; }

        // 제목 제목
        public string TITLE { get; set; }

        // 내용 내용
        public string CONTENT { get; set; }

        // 작성자 작성자
        public string WRITER { get; set; }

        // 작성일 작성일
        public DateTime? REG_DATE { get; set; }

        // 조회수 조회수
        public int? VIEW_COUNT { get; set; }

        // 댓글수 댓글수
        public int? REPLY_COUNT { get; set; }

        // BOARD 모델 복사
        public void CopyData(Board param)
        {
            this.BOARD_ID = param.BOARD_ID;
            this.TITLE = param.TITLE;
            this.CONTENT = param.CONTENT;
            this.WRITER = param.WRITER;
            this.REG_DATE = param.REG_DATE;
            this.VIEW_COUNT = param.VIEW_COUNT;
            this.REPLY_COUNT = param.REPLY_COUNT;
        }
    }
}