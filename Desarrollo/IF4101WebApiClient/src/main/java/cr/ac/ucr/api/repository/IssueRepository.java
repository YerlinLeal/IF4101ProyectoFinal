package cr.ac.ucr.api.repository;

import cr.ac.ucr.api.model.Comment;
import cr.ac.ucr.api.model.Issue;
import cr.ac.ucr.api.model.IssueDTO;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public interface IssueRepository extends JpaRepository<Issue, Integer> {
    @Query(value = "{ call listIssue(:id)}", nativeQuery = true)
    List<Issue> listIssue(@Param("id") int id);

    @Query(value = "{ call GetCommentByReport(:r_id)}", nativeQuery = true)
    IssueDTO getCommentByReport(@Param("r_id") int r_id);

}
